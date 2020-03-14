using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    class Program
    {
        private static int randomLoops = 100000;
        private static int populationSize = 100;
        private static int generationsCount = 150;
        private static float crossProbability = 0.7f;
        private static float mutationProbability = 0.1f;
        private static int tour = 5;

        static void Main(string[] args)
        {
            (List<Node> nodes, Dictionary<(int, int), float> distances) =
                DataLoader.ReadFile("Resources/berlin52.tsp");

            List<Algorithm> algorithms = new List<Algorithm>
            {
/*                new RandomAlgorithm(randomLoops, nodes, distances),
                new GreedyAlgorithm(nodes, distances),*/
                new EvolutionaryAlgorithm(nodes, distances, populationSize,
                    mutationProbability, crossProbability, generationsCount, tour)
            };

            foreach (Algorithm alg in algorithms)
            {
                DateTime start = DateTime.Now;
                Invidual resultInvidual = alg.Run();
                Console.WriteLine($"{alg.GetType()} \t = {resultInvidual} \nCzas: {DateTime.Now - start}");
            }

            //Console.ReadLine();
        }
    }
}
