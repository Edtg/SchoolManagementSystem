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
        public static List<string> GetMesages(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string UserType = Request["usertype"];
                string Username = Request["username"];
                string SenderName = Request["contact"];
                User user;
                User Sender;
                if (UserType.Equals("parent"))
                {
                    user = Database.Instance.GetParent(Username);
                    Sender = Database.Instance.GetTeacher(SenderName);
                }
                else if (UserType.Equals("teacher"))
                {
                    user = Database.Instance.GetTeacher(Username);
                    Sender = Database.Instance.GetParent(SenderName);
                }
                else
                {
                    Console.WriteLine("Get Messages Failed");
                    Response.Add("fail");
                    return Response;
                }

                List<Message> Messages = Database.Instance.GetMessages(user, Sender).ToList();

                if (Messages.Count > 0)
                {
                    foreach(Message Message in Messages)
                    {
                        Response.Add(Message.Sender.Name + "|" + Message.Content + "|" + Message.Timestamp.ToString("yyyyMMdd:HH:mm:ss"));
                    }
                    return Response;
                }
                else
                {
                    Response.Add("empty");
                    return Response;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Send Message Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> SendMessage(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string SenderType = Request["sendertype"];
                string SenderName = Request["sender"];
                User Sender;
                if (SenderType.Equals("parent"))
                {
                    Sender = Database.Instance.GetParent(SenderName);
                }
                else if (SenderType.Equals("teacher"))
                {
                    Sender = Database.Instance.GetTeacher(SenderName);
                }
                else
                {
                    Console.WriteLine("Send Message Failed");
                    Response.Add("fail");
                    return Response;
                }

                List<string> ReceiversNames = Request["receivers"].Split(",").ToList();

                List<User> Receivers = new List<User>();

                foreach (string ReceiverName in ReceiversNames)
                {
                    User Receiver;
                    if (SenderType.Equals("parent"))
                    {
                        Receiver = Database.Instance.GetTeacher(ReceiverName);
                    }
                    else if (SenderType.Equals("teacher"))
                    {
                        Receiver = Database.Instance.GetParent(ReceiverName);
                    }
                    else
                    {
                        Console.WriteLine("Send Message Failed");
                        Response.Add("fail");
                        return Response;
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
                Response.Add("success");
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Send Message Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> SendBroadcast(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string SenderName = Request["sender"];
                User Sender = Database.Instance.GetTeacher(SenderName);

                SchoolClass Class = Database.Instance.GetSchoolClass(Request["classname"]);

                List<User> Receivers = new List<User>();

                foreach (Student student in Class.StudentsMarks.Keys)
                {
                    Receivers.Add(student.StudentParent);
                }

                string MessageContent = Request["content"];
                DateTime CurrentDate = DateTime.Now;

                Message NewMessage = new Message();
                NewMessage.Sender = Sender;
                NewMessage.Receivers = Receivers;
                NewMessage.Content = MessageContent;
                NewMessage.Timestamp = CurrentDate;
                NewMessage.IsBroadcast = true;

                Database.Instance.CreateBroadcast(NewMessage);
                Console.WriteLine("Broadcast Sent");
                Response.Add("success");
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Create Broadcast Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> GetBroadcasts(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string ReceiverName = Request["parent"];
                User Receiver = Database.Instance.GetParent(ReceiverName);

                List<Message> Broadcasts = Database.Instance.GetBroadcasts(Receiver).ToList();

                if (Broadcasts.Count == 0)
                {
                    Response.Add("empty");
                    return Response;
                }

                foreach (Message Broadcast in Broadcasts)
                {
                    Response.Add(Broadcast.Sender.Name + "," + Broadcast.Content + "," + Broadcast.Timestamp);
                }
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Get Broadcasts Failed");
            }
            Response.Add("fail");
            return Response;
        }
    }
}
