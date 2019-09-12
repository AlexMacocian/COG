using COG.Graphs;
using COG.Representations;
using COG.ShortestPaths;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COG.Tests.ShortestPaths
{
    [TestClass]
    public class DijkstraSPTests
    {
        [TestMethod]
        public void SolveTest()
        {
            string[] lines = File.ReadAllLines("SPTestGraph.txt");
            int n = int.Parse(lines[0].Split(' ')[0]);
            int m = int.Parse(lines[0].Split(' ')[1]);
            double pathCost = double.Parse(lines[lines.Length - 1]);
            DirectedGraph graph = new DirectedGraph(new WeightedMatrixRepresentation(n));
            for (int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                double cost = double.Parse(tokens[2]);
                graph.AddEdge(new Edge(from, to, cost));
            }
            graph.ShortestPathSolver = new DijkstraSP();
            var path = graph.GetShortestPath(0, 5);
            double calculatedCost = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                calculatedCost += graph[path[i], path[i + 1]];
            }
            if(calculatedCost != pathCost)
            {
                Assert.Fail();
            }
        }
    }
}
