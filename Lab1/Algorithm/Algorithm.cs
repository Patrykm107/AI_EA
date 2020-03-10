using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1
{
    abstract class Algorithm
    {
        protected List<Node> nodes;
        protected Dictionary<(int, int), float> distances;

        protected Algorithm(List<Node> nodes, Dictionary<(int, int), float> distances)
        {
            this.nodes = nodes;
            this.distances = distances;
        }

        public abstract Invidual Run();

        protected void Evaluate(Invidual invidual) {
            double score = 0;

            for (int i = 0; i < invidual.genes.Count-1; i++)
            {
                score += distances[(invidual.genes[i], invidual.genes[i + 1])];
            }
            score += distances[(invidual.genes[nodes.Count - 1], invidual.genes[0])];

            invidual.score = score;
            invidual.fitness = 1.0 / score;
        }
    }
}
