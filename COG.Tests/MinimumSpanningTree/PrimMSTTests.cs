using COG.Graphs;
using COG.MinimumSpanningTree;
using COG.Representations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COG.Tests.MinimumSpanningTree
{
    [TestClass]
    public class PrimMSTTests
    {
        [TestMethod]
        public void SolveTest()
        {
            string[] lines = File.ReadAllLines("MSTTestGraph.txt");
            int n = int.Parse(lines[0].Split(' ')[0]);
            int m = int.Parse(lines[0].Split(' ')[1]);
            int mstCost = int.Parse(lines[lines.Length - 1]);
            UndirectedGraph undirectedGraph = new UndirectedGraph(new WeightedMatrixRepresentation(n));
            for (int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                double cost = double.Parse(tokens[2]);
                undirectedGraph.AddEdge(new Edge(from, to, cost));
            }
            PrimMST primMST = new PrimMST();
            undirectedGraph.MSTSolver = primMST;
            var mst = undirectedGraph.GetMinimumSpanningTree();
            if(mst.Count != n - 1)
            {
                Assert.Fail();
            }
            int totalCost = 0;
            foreach(Edge baseEdge in mst)
            {
                totalCost += (int)baseEdge.Cost;
            }
            if(totalCost != mstCost)
            {
                Assert.Fail();
            }
        }
    }
}
