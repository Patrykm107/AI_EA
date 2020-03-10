using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RandomAlgorithm : Algorithm
    {
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
                });

            return best;
        }

    }
}
