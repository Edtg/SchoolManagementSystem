using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class LoginController
    {
        public static void LoginParent(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

            try
            {
                string username = Request["username"];
                string password = Request["password"];
                User parent = Database.Instance.GetParents().Where(p => p.Name.Equals(username)).First();
                if (parent.Password.Equals(password))
                {
                    Console.WriteLine("Login Successful");
                    sw.WriteLine("success");
                    sw.Flush();
                    return;
                }
                else
                {
                    Console.WriteLine("Parent Login Failed: Invalid password");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Parent Login Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }

        public static void LoginTeacher(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

            try
            {
                string username = Request["username"];
                string password = Request["password"];
                User teacher = Database.Instance.GetTeachers().Where(p => p.Name.Equals(username)).First();
                if (teacher.Password.Equals(password))
                {
                    Console.WriteLine("Login Successful");
                    sw.WriteLine("success");
                    sw.Flush();
                    return;
                }
                else
                {
                    Console.WriteLine("Teacher Login Failed: Invalid password");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Teacher Login Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }

    }
}
