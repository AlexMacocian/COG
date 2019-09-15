using COG.Graphs;
using COG.Representations;
using COG.Traversals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COG.Tests.Traversals
{
    [TestClass]
    public class BreadthFirstSearchTests
    {
        [TestMethod]
        public void TraverseTest()
        {
            string[] lines = File.ReadAllLines("SPTestGraph.txt");
            int n = int.Parse(lines[0].Split(' ')[0]);
            int m = int.Parse(lines[0].Split(' ')[1]);
            double pathCost = double.Parse(lines[lines.Length - 1]);
            DirectedGraph graph = new DirectedGraph(new MatrixRepresentation(n));
            for (int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                double cost = double.Parse(tokens[2]);
                graph.AddEdge(new Edge(from, to, cost));
            }
            List<int> order = new List<int>();
            BreadthFirstSearch bfs = new BreadthFirstSearch();
            bfs.Initialize(graph, 0);
            int curNode;
            while (bfs.Traverse(out curNode))
            {
                order.Add(curNode);
            }
            if(order.Count != 6)
            {
                Assert.Fail();
            }
        }
    }
}
