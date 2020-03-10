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
            (List<Node> nodes, Dictionary<(int, int), float> distances) =
                DataLoader.ReadFile("Resources/berlin11_modified.tsp");

            List<Algorithm> algorithms = new List<Algorithm>
            {
                new RandomAlgorithm(100000, nodes, distances),
                new GreedyAlgorithm(nodes, distances)
            };

            foreach (Algorithm alg in algorithms)
            {
                DateTime start = DateTime.Now;
                Invidual resultInvidual = alg.Run();
                Console.WriteLine($"{alg.GetType()} \t = {resultInvidual} \nCzas: {DateTime.Now - start}");
            }



            Console.ReadLine();
        }
    }
}
