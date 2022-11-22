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
        public static void HandleRequest(TcpClient Client, string Request)
        {
            if (Client == null || Request == "")
                return;

            Dictionary<string, string> ParsedRequest = new Dictionary<string, string>();
            try
            {
                ParsedRequest = ParseRequest(Request);
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

            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

            switch (ParsedRequest["instruction"])
            {
                case "loginparent":
                    LoginController.LoginParent(ParsedRequest, Client);
                    break;
                case "loginteacher":
                    LoginController.LoginTeacher(ParsedRequest, Client);
                    break;
                case "parentclasses":
                    SchoolClassesController.GetParentClasses(ParsedRequest, Client);
                    break;
                case "joinclass":
                    SchoolClassesController.JoinClass(ParsedRequest, Client);
                    break;
                case "teacherclasses":
                    SchoolClassesController.GetTeacherClasses(ParsedRequest, Client);
                    break;
                case "createclass":
                    SchoolClassesController.CreateClass(ParsedRequest, Client);
                    break;
                case "updateclass":
                    SchoolClassesController.UpdateClass(ParsedRequest, Client);
                    break;
                case "classparents":
                    SchoolClassesController.GetClassParents(ParsedRequest, Client);
                    break;
                case "getmessages":
                    MessageController.GetMesages(ParsedRequest, Client);
                    break;
                case "sendmessage":
                    MessageController.SendMessage(ParsedRequest, Client);
                    break;
                case "getbroadcasts":
                    MessageController.GetBroadcasts(ParsedRequest, Client);
                    break;
                case "sendbroadcast":
                    MessageController.SendBroadcast(ParsedRequest, Client);
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
