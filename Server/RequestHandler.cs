using System;
using System.Collections.Generic;
using System.Globalization;
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

            List<string> Response = new List<string>();

            switch (ParsedRequest["instruction"])
            {
                case "loginparent":
                    Response = LoginController.LoginParent(ParsedRequest);
                    break;
                case "loginteacher":
                    Response = LoginController.LoginTeacher(ParsedRequest);
                    break;
                case "parentclasses":
                    Response = SchoolClassesController.GetParentClasses(ParsedRequest);
                    break;
                case "joinclass":
                    Response = SchoolClassesController.JoinClass(ParsedRequest);
                    break;
                case "teacherclasses":
                    Response = SchoolClassesController.GetTeacherClasses(ParsedRequest);
                    break;
                case "getclass":
                    Response = SchoolClassesController.GetClassInfo(ParsedRequest);
                    break;
                case "getclassmarks":
                    Response = SchoolClassesController.GetClassMarks(ParsedRequest);
                    break;
                case "createclass":
                    Response = SchoolClassesController.CreateClass(ParsedRequest);
                    break;
                case "updateclass":
                    Response = SchoolClassesController.UpdateClass(ParsedRequest);
                    break;
                case "updatemarks":
                    Response = SchoolClassesController.UpdateMarks(ParsedRequest);
                    break;
                case "removeclass":
                    Response = SchoolClassesController.RemoveClass(ParsedRequest);
                    break;
                case "classparents":
                    Response = SchoolClassesController.GetClassParents(ParsedRequest);
                    break;
                case "getmessages":
                    Response = MessageController.GetMesages(ParsedRequest);
                    break;
                case "sendmessage":
                    Response = MessageController.SendMessage(ParsedRequest);
                    break;
                case "getbroadcasts":
                    Response = MessageController.GetBroadcasts(ParsedRequest);
                    break;
                case "sendbroadcast":
                    Response = MessageController.SendBroadcast(ParsedRequest);
                    break;
                case "setsimulateddate":
                    Session.Instance.SimulatedDate = DateTime.ParseExact(ParsedRequest["date"], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
                    Response = new List<string> { "success" };
                    break;



                default:
                    Response.Add("invalid");
                    break;
            }

            foreach (var response in Response)
            {
                sw.WriteLine(response.ToString());
            }
            sw.Flush();
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
