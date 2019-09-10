using COG.Graphs;
using COG.Representations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COG.Tests.Graphs
{
    [TestClass]
    public class UndirectedGraphTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph(new MatrixRepresentation(3));
            if (undirectedGraph.Nodes != 3)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void AddEdgeTest()
        {
            string[] lines = File.ReadAllLines("TestGraph.txt");
            int n = int.Parse(lines[0].Split(' ')[0]);
            int m = int.Parse(lines[1].Split(' ')[1]);
            UndirectedGraph undirectedGraph = new UndirectedGraph(new MatrixRepresentation(n));
            for (int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                double cost = double.Parse(tokens[2]);
                undirectedGraph.AddEdge(new BaseEdge(from, to, cost));
            }
            if (undirectedGraph.Edges != m)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void RemoveEdgeTest()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph(new MatrixRepresentation(2));
            undirectedGraph.AddEdge(new BaseEdge(0, 1, 1));
            if (undirectedGraph.Edges != 1)
            {
                Assert.Fail();
            }
            undirectedGraph.RemoveEdge(new BaseEdge(0, 1, 1));
            if (undirectedGraph.Edges > 0)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void GetEdgesTest()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph(new MatrixRepresentation(5));
            for (int i = 0; i < 5; i++)
            {
                undirectedGraph.AddEdge(new BaseEdge(0, i, i));
            }
            if (undirectedGraph.GetEdges(new BaseNode(0)).Count != 5)
            {
                Assert.Fail();
            }
        }
    }
}
