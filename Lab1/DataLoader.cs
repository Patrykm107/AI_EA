using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class DataLoader
    {
        private static string BEGIN_FILE = "NODE_COORD_SECTION";
        private static string END_FILE = "EOF";

        public static List<Node> readFile(string fileName)
        {
            List<string> lines = File.ReadAllLines(fileName).ToList();
            int begin = lines.IndexOf(BEGIN_FILE);
            int end = lines.IndexOf(END_FILE);

            lines = lines.GetRange(begin + 1, end - begin - 1);

            char[] splitChars = {' '};

            List<Node> nodes = new List<Node>();

            lines.ForEach(
                line =>
                {
                    string[] nums = line.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

                    int id = int.Parse(nums[0]);
                    float x = float.Parse(nums[1], CultureInfo.InvariantCulture);
                    float y = float.Parse(nums[2], CultureInfo.InvariantCulture);

                    nodes.Add(new Node(id, x, y));
                }
            );

            return nodes;
        }
    }
}
