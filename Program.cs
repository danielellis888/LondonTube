using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonTube
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            string startNode = "East Ham";

            GraphTraversal gt = new GraphTraversal();
            gt.TraverseGraph(n, startNode);
        }
    }
}
