using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherClient
{
    internal class Session
    {
        private static Session instance;
        private static object padlock = new object();

        public static Session Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Session();
                    }
                    return instance;
                }
            }
        }

        public string TeacherName { get; set; }

        public Session()
        {

        }
    }
}
