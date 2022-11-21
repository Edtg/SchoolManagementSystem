using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class RequestHandler
    {
        public static void HandleRequest(TcpClient client, string request)
        {
            if (client == null || request == "")
                return;

            Dictionary<string, string> ParsedRequest = new Dictionary<string, string>();
            try
            {
                ParsedRequest = ParseRequest(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Request: " + ex.Message);
            }

            if (!ParsedRequest.ContainsKey("instruction"))
            {
                Console.WriteLine("Invalid Request: No instruction");
                return;
            }

            Console.WriteLine("Processing Request: " + ParsedRequest["instruction"]);

            StreamWriter sw = new StreamWriter(client.GetStream(), Encoding.ASCII);

            switch (ParsedRequest["instruction"])
            {
                case "loginparent":
                    try
                    {
                        string username = ParsedRequest["username"];
                        string password = ParsedRequest["password"];
                        Parent parent = Database.Instance.GetParents().Where(p => p.Name.Equals(username)).First();
                        if (parent.Password.Equals(password))
                        {
                            Console.WriteLine("Login Successful");
                            sw.WriteLine("success");
                            sw.Flush();
                            break;
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
                    break;
                case "loginteacher":
                    try
                    {
                        string username = ParsedRequest["username"];
                        string password = ParsedRequest["password"];
                        Teacher teacher = Database.Instance.GetTeachers().Where(p => p.Name.Equals(username)).First();
                        if (teacher.Password.Equals(password))
                        {
                            Console.WriteLine("Login Successful");
                            sw.WriteLine("success");
                            sw.Flush();
                            break;
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
                    break;
                case "parentclasses":
                    try
                    {
                        string SortBy = ParsedRequest["sort"];
                        string ParentName = ParsedRequest["parent"];
                        Parent parent = Database.Instance.GetParents().Where(p => p.Name.Equals(ParentName)).First();
                        Student student = Database.Instance.GetStudents().Where(s => s.StudentParent.Equals(parent)).First();
                        List<SchoolClass> Classes = Database.Instance.GetSchoolClasses().Where(c => c.StudentsMarks.ContainsKey(student)).ToList();

                        if (SortBy.Equals("date"))
                        {
                            Classes = Classes.OrderBy(c => c.Date).ToList();
                        }

                        sw.WriteLine("class|date");

                        foreach (SchoolClass schoolClass in Classes)
                        {
                            sw.WriteLine(schoolClass.Name + "|" + schoolClass.Date.ToString());
                        }
                        sw.Flush();
                        break;
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("Get Classes Failed");
                    }
                    sw.WriteLine("fail");
                    sw.Flush();
                    break;
                case "joinclass":
                    try
                    {
                        string Code = ParsedRequest["code"];
                        string ParentName = ParsedRequest["parent"];
                        SchoolClass schoolClass = Database.Instance.GetSchoolClasses().Where(c => c.JoinCode.Equals(Code)).First();
                        Parent parent = Database.Instance.GetParents().Where(p => p.Name.Equals(ParentName)).First();
                        Student student = Database.Instance.GetStudents().Where(s => s.StudentParent.Equals(parent)).First();

                        if (!schoolClass.StudentsMarks.ContainsKey(student))
                        {
                            schoolClass.StudentsMarks.Add(student, -1);
                            Console.WriteLine("Student joined " + schoolClass.Name);
                            sw.WriteLine("success");
                            sw.Flush();
                            break;
                        }
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("Join Class Failed");
                    }
                    sw.WriteLine("fail");
                    sw.Flush();
                    break;



                default:
                    sw.WriteLine("invalid");
                    sw.Flush();
                    break;
            }

            
        }

        public static Dictionary<string, string> ParseRequest(string request)
        {
            var Result = new Dictionary<string, string>();

            var Parameters = request.Split("|");
            foreach (var Param in Parameters)
            {
                var lhs = Param.Split("=")[0].Trim();
                var rhs = Param.Split("=")[1].Trim();
                if (!Result.ContainsKey(lhs))
                {
                    Result.Add(lhs, rhs);
                }
            }
            return Result;
        }
    }
}
