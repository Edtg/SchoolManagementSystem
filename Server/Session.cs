using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
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

        public DateTime SimulatedDate { get; set; }

        public Session()
        {

        }
    }
}
