using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RandomAlgorithm : Algorithm
    {
        public RandomAlgorithm(int populationSize, List<Node> nodes) : base(populationSize, nodes) { }

        override public Invidual run()
        {
            List<Invidual> population = InvidualUtils.generateRandomPopulation(populationSize, nodes.Count);

            Invidual best = population[0];

            population.ForEach(
                current => {
                    evaluate(current);
                    if (current.fitness > best.fitness) best = current;
                });

            return best;
        }

    }
}
