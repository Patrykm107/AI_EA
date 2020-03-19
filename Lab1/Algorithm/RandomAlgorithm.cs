using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RandomAlgorithm : Algorithm
    {
        private static string FILE_NAME = $"RandomAlg_{DateTime.Now.Day}__{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.csv";

        private int populationSize;
        public RandomAlgorithm(int populationSize, List<Node> nodes, Dictionary<(int, int), float> distances) : base(nodes, distances) {
            this.populationSize = populationSize;
        }

        override public Invidual Run()
        {
            List<Invidual> population = InvidualUtils.generateRandomPopulation(populationSize, nodes.Count);

            Invidual best = population[0];

            population.ForEach(
                current => {
                    Evaluate(current);
                    if (current.fitness > best.fitness) best = current;

                    File.AppendAllText(FILE_NAME, $"{current.score};\n");
                });



            return best;
        }

    }
}
