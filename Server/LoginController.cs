using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class LoginController
    {
        public static List<string> LoginParent(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string username = Request["username"];
                string password = Request["password"];
                User parent = Database.Instance.GetParents().Where(p => p.Name.Equals(username)).First();
                if (parent.Password.Equals(password))
                {
                    Console.WriteLine("Login Successful");
                    Response.Add("success");
                    return Response;
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
            Response.Add("fail");
            return Response;
        }

        public static List<string> LoginTeacher(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string username = Request["username"];
                string password = Request["password"];
                User teacher = Database.Instance.GetTeachers().Where(p => p.Name.Equals(username)).First();
                if (teacher.Password.Equals(password))
                {
                    Console.WriteLine("Login Successful");
                    Response.Add("success");
                    return Response;
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
            Response.Add("fail");
            return Response;
        }

    }
}
