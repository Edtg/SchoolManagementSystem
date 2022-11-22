using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class MessageController
    {
        public static void GetMesages(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

            try
            {
                string UserType = Request["usertype"];
                string Username = Request["username"];
                string SenderName = Request["contact"];
                User user;
                User Sender;
                if (UserType.Equals("parent"))
                {
                    user = Database.Instance.GetParents().Where(p => p.Name.Equals(Username)).First();
                    Sender = Database.Instance.GetTeachers().Where(t => t.Name.Equals(SenderName)).First();
                }
                else if (UserType.Equals("teacher"))
                {
                    user = Database.Instance.GetTeachers().Where(t => t.Name.Equals(Username)).First();
                    Sender = Database.Instance.GetParents().Where(p => p.Name.Equals(SenderName)).First();
                }
                else
                {
                    Console.WriteLine("Get Messages Failed");
                    sw.WriteLine("fail");
                    sw.Flush();
                    return;
                }

                List<Message> Messages = Database.Instance.GetMessages(user, Sender).ToList();

                if (Messages.Count > 0)
                {
                    foreach(Message Message in Messages)
                    {
                        sw.WriteLine(Message.Sender.Name + "|" + Message.Content + "|" + Message.Timestamp.ToString("yyyyMMdd:HH:mm:ss"));
                    }
                    sw.Flush();
                    return;
                }
                else
                {
                    sw.WriteLine("empty");
                    sw.Flush();
                    return;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Send Message Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }

        public static void SendMessage(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

            try
            {
                string SenderType = Request["sendertype"];
                string SenderName = Request["sender"];
                User Sender;
                if (SenderType.Equals("parent"))
                {
                    Sender = Database.Instance.GetParents().Where(p => p.Name.Equals(SenderName)).First();
                }
                else if (SenderType.Equals("teacher"))
                {
                    Sender = Database.Instance.GetTeachers().Where(t => t.Name.Equals(SenderName)).First();
                }
                else
                {
                    Console.WriteLine("Send Message Failed");
                    sw.WriteLine("fail");
                    sw.Flush();
                    return;
                }

                List<string> ReceiversNames = Request["receivers"].Split(",").ToList();

                List<User> Receivers = new List<User>();

                foreach (string ReceiverName in ReceiversNames)
                {
                    User Receiver;
                    if (SenderType.Equals("parent"))
                    {
                        Receiver = Database.Instance.GetTeachers().Where(t => t.Name.Equals(ReceiverName)).First();
                    }
                    else if (SenderType.Equals("teacher"))
                    {
                        Receiver = Database.Instance.GetParents().Where(p => p.Name.Equals(ReceiverName)).First();
                    }
                    else
                    {
                        Console.WriteLine("Send Message Failed");
                        sw.WriteLine("fail");
                        sw.Flush();
                        return;
                    }

                    Receivers.Add(Receiver);
                }

                string MessageContent = Request["content"];
                DateTime CurrentDate = DateTime.Now;

                Message NewMessage = new Message();
                NewMessage.Sender = Sender;
                NewMessage.Receivers = Receivers;
                NewMessage.Content = MessageContent;
                NewMessage.Timestamp = CurrentDate;
                NewMessage.IsBroadcast = false;

                Database.Instance.CreateMessage(NewMessage);
                Console.WriteLine("Message Sent");
                sw.WriteLine("success");
                sw.Flush();
                return;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Send Message Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }

        public static void SendBroadcast(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);
        }

        public static void GetBroadcasts(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);
        }
    }
}
