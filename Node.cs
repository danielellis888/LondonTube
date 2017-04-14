using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonTube
{
    class Node
    {
        //the node contains the corresponding key and visited because in c# you cannot modify a dictionary's key even if its an object
        public string Key { get; set; }
        public bool Visited { get; set; }
        public int Count { get; set; }
        public List<string> Stations { get; set; }

        public Node(string fromStation, string toStation)
        {
            this.Key = fromStation;
            this.Visited = false;
            this.Stations = new List<string>();
            this.Stations.Add(toStation);
        }
    }
}
