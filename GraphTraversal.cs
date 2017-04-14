using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LondonTube
{
    class GraphTraversal
    {
        private Dictionary<string, Node> graph { get; set; }
        private List<string> endNodes { get; set; }
        private List<string> intermediateNodes { get; set; }


        public GraphTraversal()
        {
            this.graph = new Dictionary<string, Node>();
            this.endNodes = new List<string>();
            this.intermediateNodes = new List<string>();

            fillGraph();
        }

        private void fillGraph()
        {
            string directory = Directory.GetCurrentDirectory().Replace(@"\bin", "").Replace(@"Debug", "");
            //Tube Line,From Station,To Station
            string[] lines = File.ReadAllLines(Path.Combine(directory, "London_tube_lines.csv"));

            for (int i = 1; i < lines.Length; i++)
            {
                string row = lines[i];

                string[] columns = row.Split(',');

                string tubeLine = columns[0];
                string fromStation = columns[1].ToLower();
                string toStation = columns[2].ToLower();

                addToGraph(fromStation, toStation);

                //the to station needs to be the from station as well for my graph
                addToGraph(toStation, fromStation);
            }
        }

        /// <summary>
        /// Adds the from station and to station to graph by the from station being a key and the to station 
        /// being added to that keys list of stations
        /// </summary>
        /// <param name="fromStation"></param>
        /// <param name="toStation"></param>
        private void addToGraph(string fromStation, string toStation)
        {
            Node toNode = new Node(fromStation, toStation);

            if (this.graph.ContainsKey(fromStation))
            {

                if (!this.graph[fromStation].Stations.Where(g => g == toStation).Any())
                    this.graph[fromStation].Stations.Add(toStation);
            }
            else
                this.graph.Add(fromStation, new Node(fromStation, toStation));
        }

        public void TraverseGraph(int n, string startNode)
        {
            startNode = startNode.ToLower();
    
            if (this.graph.ContainsKey(startNode))
            {
                Node to = this.graph[startNode];

                goToStation(n, to);
            }

            //find and remove any nodes that are in the endNodes but were reached by a shorter route which is why
            //they would be in the intermediate nodes list
            List<string> intersectingNodes = this.endNodes.Intersect(this.intermediateNodes).ToList();

            foreach (var tempNode in intersectingNodes)
                this.endNodes.Remove(tempNode);

            //remove any duplicates. Duplicates are nodes that are reached multiple ways but still maintain the minimum station distance
            this.endNodes = this.endNodes.Distinct().ToList();

            //sort the list of strings. default is alphabetically
            this.endNodes.Sort();

            foreach (var end in endNodes)
                Console.WriteLine(end);

            Console.WriteLine("\nPlease Enter to exit.");
            Console.ReadLine();
        }

        private void goToStation(int n, Node startNode)
        {
            //sets node to visited so that it isn't visited again in the recursion
            startNode.Visited = true;

            //base case. once n == 0 the startNode is really the endNode
            if (n == 0)
            {
                //set the end Node back to false so that node can be tried again for other paths. Canning Town is an example.
                startNode.Visited = false;
                this.endNodes.Add(startNode.Key);
                return;
            }
            else
            {
                //keep track of all stations that were reached in under N stops
                this.intermediateNodes.Add(startNode.Key);
            }

            n--;

            for (int i = 0; i < startNode.Stations.Count; i++)
            {
                if (this.graph.ContainsKey(startNode.Stations[i]))
                {

                    if (!this.graph[startNode.Stations[i]].Visited)
                        goToStation(n, this.graph[startNode.Stations[i]]);
                }
            }

        }

        /// <summary>
        /// prints out graph rows to command line
        /// </summary>
        public void PrintGraph()
        {
            foreach (var g in this.graph)
            {
                string output = g.Key + "," + string.Join("|", g.Value.Stations.ToArray());
                Console.WriteLine(output);
            }
        }

    }
}
