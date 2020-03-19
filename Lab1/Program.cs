using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        private static string FILE_NAME = $"EA_Summary_{DateTime.Now.Day}__{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.csv";

        private static int randomLoops = 10000;
        private static int populationSize = 200;
        private static int generationsCount = 300;
        private static float crossProbability = 0.7f;
        private static float mutationProbability = 0.9f;
        private static int tour = 4;

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

/*                for (int i = 0; i < 10; i++)
                {
                    File.AppendAllText(FILE_NAME, $"{alg.Run().score};\n");
                }*/

                Console.WriteLine($"{alg.GetType()} \t = {resultInvidual} \nCzas: {DateTime.Now - start}");
            }
            Console.ReadLine();
        }
    }
}
