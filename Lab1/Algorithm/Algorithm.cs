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
        protected int populationSize;
        protected List<Node> nodes;

        protected Algorithm(int populationSize, List<Node> nodes)
        {
            this.populationSize = populationSize;
            this.nodes = nodes;
        }

        public abstract Invidual run();

        protected void evaluate(Invidual invidual) {
            double score = 0;

            for (int i = 0; i < invidual.gene.Count-1; i++)
            {
                score += Vector2.Distance(nodes[invidual.gene[i]-1].coords, nodes[invidual.gene[i+1]-1].coords);
            }

            score *= 2;

            invidual.score = score;
            invidual.fitness = 1.0 / score;
        }
    }
}
