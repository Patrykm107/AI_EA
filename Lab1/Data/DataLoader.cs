using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DataLoader
    {
        private static readonly string BEGIN_FILE = "NODE_COORD_SECTION";
        private static readonly string END_FILE = "EOF";

        public static (List<Node>, Dictionary<(int,int), float>) ReadFile(string fileName)
        {
            List<string> lines = File.ReadAllLines(fileName).ToList();
            int begin = lines.IndexOf(BEGIN_FILE);
            int end = lines.IndexOf(END_FILE);

            lines = lines.GetRange(begin + 1, end - begin - 1);

            char[] splitChars = {' '};

            List<Node> nodes = new List<Node>();
            Dictionary<(int, int), float> distances = new Dictionary<(int, int), float>();
            List<int> visited = new List<int>();

            lines.ForEach(
                line =>
                {
                    string[] nums = line.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

                    int id = int.Parse(nums[0]);
                    float x = float.Parse(nums[1], CultureInfo.InvariantCulture);
                    float y = float.Parse(nums[2], CultureInfo.InvariantCulture);

                    Node newNode = new Node(id, x, y);

                    visited.ForEach(
                        nodeId =>
                        {
                            if (!distances.ContainsKey((newNode.id, nodeId))) {
                                float distance = Vector2.Distance(newNode.coords, nodes[nodeId - 1].coords); //node id starts at 1, list at 0
                                    distances.Add((newNode.id, nodeId), distance);
                                distances.Add((nodeId, newNode.id), distance);
                            }
                        });
                    distances.Add((newNode.id, newNode.id), 0);
                    visited.Add(newNode.id);

                    nodes.Add(newNode);
                }
            );

            return (nodes, distances);
        }
    }
}
