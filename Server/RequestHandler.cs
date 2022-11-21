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
                        Parent parent = Database.Instance.GetParents().Where(p => p.Name == username).First();
                        if (parent.Password == password)
                        {
                            Console.WriteLine("Login Successful");
                            sw.WriteLine("success");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Parent Login Failed: Invalid password");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Parent Login Failed");
                    }
                    sw.WriteLine("fail");
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
