using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PivotSettlers2
{
    class Controller
    {
        const String HOSTNAME = "www.google.com";
        const int PORT = 7;

        int playerNumber;
        NetClient net = new NetClient();
        //----resource IDs----
        //-wheat: 	    wt
        //-ore: 		o
        //-sheep: 	    s
        //-brick: 		b
        //-wood:		wd
        Dictionary<string, int> resources = new Dictionary<string, int>();
        public Controller()
        {
            resources.Add("wt", 0);
            resources.Add("o", 0);
            resources.Add("s", 0);
            resources.Add("b", 0);
            resources.Add("wd", 0);
        }
        public string TryConnection()
        {
            return net.Connect(HOSTNAME, PORT);
        }

        /// <summary>
        /// Takes an alter player resource command and parses it and changes this players resources
        /// </summary>
        /// <param name="s">the alter player command to parse</param>
        public void ParseChange(String s)
        {
            //p [player ID] + [number] [resource ID] 
            //[0] = p, [1] = [playerID], [2] = [+ or -], [3] = [num], [4] = [resource ID]
            String[] command = s.Split();

            if (int.Parse(command[1]) == playerNumber)
            {
                int prevValue = resources[command[4]];
                if (command[2] == "+")
                {
                    resources[command[4]] = prevValue + int.Parse(command[3]);
                }
                else
                {
                    resources[command[4]] = prevValue - int.Parse(command[3]);
                }
            }
        }
        /// <summary>
        /// Instructs the server to build a building of kind 'id'
        /// </summary>
        /// <param name="id">the kind of building to build, see in method</param>
        /// <returns>true if successful, false otherwise</returns>
        public bool Build(String id)
        {
            String result = net.Send("p " + playerNumber + " build " + id);
            if(result.Equals("Operation Timeout"))
            {
                return false;
            }
            return true;
        }
        public string Send(String s)
        {
            return net.Send(s);
        }
    }
}
