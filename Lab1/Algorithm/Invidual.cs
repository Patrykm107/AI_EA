using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Invidual
    {
        public List<int> genes;
        public double fitness = 0;
        public double score;

        public Invidual() { }
        public Invidual(List<int> gene)
        {
            this.genes = gene;
        }

        public Invidual(Invidual invidual)
        {
            this.genes = new List<int>(invidual.genes);
        }

        override public string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (int gene in genes)
            {
                builder.Append($"{gene} ");
            }
            builder.Append($"\tScore: {score}");

            return builder.ToString();
        }
    }

    static class InvidualUtils
    {
        static Random random = new Random();

        public static Invidual generateRandomInvidual(int geneSize)
        {
            List<int> gene = Enumerable.Range(1, geneSize).ToList();
            return new Invidual(gene.OrderBy(_ => random.Next()).ToList());
        }

        public static List<Invidual> generateRandomPopulation(int populationSize, int geneSize)
        {
            List<Invidual> population = new List<Invidual>();

            for(int i = 0; i < populationSize; i++)
            {
                population.Add(generateRandomInvidual(geneSize));
            }

            return population;
        }
    }
}
