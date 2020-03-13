using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class EvolutionaryAlgorithm : Algorithm
    {
        private int populationSize;
        private float mutationProb;
        private int generationsCount;
        private static Random random = new Random();

        public EvolutionaryAlgorithm(List<Node> nodes, Dictionary<(int, int), float> distances, int populationSize,
            float mutationProb, int generationsCount)
            : base(nodes, distances) {
            this.populationSize = populationSize;
            this.mutationProb = mutationProb;
            this.generationsCount = generationsCount;
        }

        public override Invidual Run()
        {
            throw new NotImplementedException();
        }

        //Inversion
        private void Mutate(Invidual invidual)
        {
            if (random.NextDouble() < mutationProb)
            {
                int p1, p2;
                (p1, p2) = generateUniqueRandomPoints(invidual.genes.Count);

                if (p1 < p2)
                {
                    invidual.genes.Reverse(p1, p2 - p1 + 1);
                } 
                else
                {   //Inversion based on list being a circle instead straight line

                    int countFirstPart = invidual.genes.Count - p1, countSecondPart = p2 + 1;
                    List<int> notMutate = invidual.genes.GetRange(p2 + 1, p1 - p2 - 1);
                    List<int> mutation = invidual.genes.GetRange(p1, countFirstPart);
                    mutation.AddRange(invidual.genes.GetRange(0, countSecondPart));
                    mutation.Reverse();

                    List<int> mutated = mutation.GetRange(mutation.Count - countSecondPart, countSecondPart);
                    mutated.AddRange(notMutate);
                    mutated.AddRange(mutation.GetRange(0, countFirstPart));

                    invidual.genes = mutated;
                }


            }
            
        }

        //Ordered Crossover
        private Invidual Crossover(Invidual parent1, Invidual parent2)
        {
            int p1, p2;
            (p1, p2) = generateUniqueRandomPoints(nodes.Count);

            if (p1 > p2)
            {
                int h = p1;
                p1 = p2;
                p2 = h;
            }

            List<int> part1 = parent1.genes.GetRange(p1, p2 - p1 + 1);
            List<int> part2 = new List<int>(parent2.genes);
            part1.ForEach(
                g =>
                {
                    part2.Remove(g);
                }
                );

            List<int> newGenes = part2.GetRange(0, p1);
            newGenes.AddRange(part1);
            newGenes.AddRange(part2.GetRange(p1, part2.Count - p1));

            return new Invidual(newGenes);
        }

        private (int, int) generateUniqueRandomPoints(int max)
        {
            int p1 = random.Next(max);
            int p2 = random.Next(max);
            while (p1 == p2)
            {
                p2 = random.Next(max);
            }

            return (p1, p2);
        }
    }
}
