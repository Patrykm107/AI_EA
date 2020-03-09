using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Invidual
    {
        public List<int> gene;
        public double fitness = 0;
        public double score;

        public Invidual(List<int> gene)
        {
            this.gene = gene;
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

            for(int i = 0; i<populationSize; i++)
            {
                population.Add(generateRandomInvidual(geneSize));
            }

            return population;
        }
    }
}
