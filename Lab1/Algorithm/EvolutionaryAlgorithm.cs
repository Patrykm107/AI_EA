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
        public void Mutate(Invidual invidual)
        {
            Random random = new Random();
            if (random.NextDouble() < mutationProb)
            {
                int p1 = random.Next(invidual.genes.Count);
                int p2 = random.Next(invidual.genes.Count);
                while (p1 == p2)
                {
                    p2 = random.Next(invidual.genes.Count);
                }

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

        private (Invidual, Invidual) Crossover(Invidual parent1, Invidual parent2)
        {

            throw new NotImplementedException();
        }
    }
}
