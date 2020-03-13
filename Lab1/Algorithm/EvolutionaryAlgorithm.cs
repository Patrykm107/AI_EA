using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class EvolutionaryAlgorithm : Algorithm
    {
        private static Random random = new Random();

        private int populationSize;
        private float mutationProb;
        private float crossoverProb;
        private int generationsCount;
        private int tour;


        public EvolutionaryAlgorithm(List<Node> nodes, Dictionary<(int, int), float> distances, int populationSize,
            float mutationProb, float crossoverProb, int generationsCount, int tour)
            : base(nodes, distances) {
            this.populationSize = populationSize;
            this.mutationProb = mutationProb;
            this.crossoverProb = crossoverProb;
            this.generationsCount = generationsCount;
            this.tour = tour;
        }

        public override Invidual Run()
        {
            List<Invidual> population = InvidualUtils.generateRandomPopulation(populationSize, nodes.Count);
            List<Invidual> newPopulation;
            Invidual bestInvidual = new Invidual();

            population.ForEach(
                inv =>
                {
                    Evaluate(inv);
                });

            for(int i = 0; i < generationsCount; i++)
            {
                newPopulation = new List<Invidual>();
                while (newPopulation.Count < this.populationSize)
                {
                    Invidual parent1 = TournamentSelection(population);
                    Invidual parent2 = TournamentSelection(population);

                    Invidual kid = Crossover(parent1, parent2);
                    if (random.NextDouble() < mutationProb) { Mutate(kid); }

                    Evaluate(kid);
                    newPopulation.Add(kid);

                    if (kid.fitness > bestInvidual.fitness)
                    {
                        bestInvidual = kid;
                    }
                }
                population = newPopulation;
            }

            return bestInvidual;
        }

        //Inversion
        private void Mutate(Invidual invidual)
        {
            List<int> points = GenerateUniqueRandomPoints(2, invidual.genes.Count);
            int p1 = points[0], p2 = points[1];

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

        //Ordered Crossover
        private Invidual Crossover(Invidual parent1, Invidual parent2)
        {
            List<int> points = GenerateUniqueRandomPoints(2, nodes.Count);
            int p1 = points[0], p2 = points[1];

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

        private Invidual TournamentSelection(List<Invidual> population)
        {
            List<int> invidualIds = GenerateUniqueRandomPoints(tour, nodes.Count);
            Invidual bestInvidual = new Invidual();
            invidualIds.ForEach(
                id =>
                {
                    if(population[id].fitness > bestInvidual.fitness)
                    {
                        bestInvidual = population[id];
                    }
                });
            return bestInvidual;
        }

        private Invidual RouletteSelection(List<Invidual> population)
        {
            double sum = 0;
            List<double> probabilities = new List<double>();
            population.ForEach(
                inv =>
                {
                    sum += inv.fitness;
                    probabilities.Add(sum);
                }
                );
            probabilities.ForEach(p => p /= sum);

            int invidualId = probabilities.BinarySearch(random.NextDouble());
            if (invidualId < 0)
            {
                invidualId = ~invidualId + 1;
            }

            return population[invidualId];
        }

        private List<int> GenerateUniqueRandomPoints(int count, int max)
        {
            List<int> points = new List<int>();
            for(int i = 0; i < count; i++)
            {
                int p = random.Next(max);
                while (points.Contains(p))
                {
                    p = random.Next(max);
                }
                points.Add(p);
            }

            return points;
        }
    }
}
