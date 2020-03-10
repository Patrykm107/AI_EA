using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class GreedyAlgorithm : Algorithm
    {
        public GreedyAlgorithm(List<Node> nodes, Dictionary<(int, int), float> distances) : base(nodes, distances) {}

        public override Invidual Run()
        {
            Invidual bestInvidual = new Invidual();
            
            foreach (Node node in nodes)
            {
                Node current = node;
                List<Node> unvisited = new List<Node>(nodes);
                List<Node> visited = new List<Node>();
                unvisited.Remove(current);
                visited.Add(current);

                for(int i = 0; i < nodes.Count-1; i++)
                {
                    Node bestNode = unvisited[0];
                    foreach(Node n in unvisited)
                    {
                        if (distances[(current.id, n.id)] < distances[(current.id, bestNode.id)])
                        {
                            bestNode = n;
                        }
                    }
                    
                    visited.Add(bestNode);
                    unvisited.Remove(bestNode);

                    current = bestNode;
                }

                Invidual newInvidual = new Invidual(visited.Select(n => n.id).ToList());
                Evaluate(newInvidual);

                if (newInvidual.fitness > bestInvidual.fitness)
                {
                    bestInvidual = newInvidual;
                }
            }

            return bestInvidual;
        }
    }
}
