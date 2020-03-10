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

        public EvolutionaryAlgorithm(List<Node> nodes, Dictionary<(int, int), float> distances, int populationSize,
            float mutationProb)
            : base(nodes, distances) {
            this.populationSize = populationSize;
            this.mutationProb = mutationProb;
        }

        public override Invidual Run()
        {
            throw new NotImplementedException();
        }

        //Inwersja
        private void Mutate(Invidual invidual)
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

                if (p2 < p1)
                {
                    int h = p1;
                    p1 = p2;
                    p2 = h;
                }

                invidual.genes.Reverse(p1, p2 - p1);
            }
            
        }

        private (Invidual, Invidual) Crossover(Invidual parent1, Invidual parent2)
        {


            throw new NotImplementedException();
        }
    }
}
