using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = DataLoader.readFile("Resources/berlin11_modified.tsp");

            Algorithm algorithm = new RandomAlgorithm(1000000, nodes);
            Invidual bestRandom = algorithm.run();
            Console.WriteLine($"Algorytm losowy score = {bestRandom.score}");
            Console.ReadLine();
        }
    }
}
