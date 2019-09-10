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
    public class DirectedGraphTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            DirectedGraph directedGraph = new DirectedGraph(new MatrixRepresentation(3));
            if(directedGraph.Nodes != 3)
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
            DirectedGraph directedGraph = new DirectedGraph(new MatrixRepresentation(n));
            for(int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                double cost = double.Parse(tokens[2]);
                directedGraph.AddEdge(new BaseEdge(from, to, cost));
            }
            if(directedGraph.Edges != m)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void RemoveEdgeTest()
        {
            DirectedGraph directedGraph = new DirectedGraph(new MatrixRepresentation(2));
            directedGraph.AddEdge(new BaseEdge(0, 1, 1));
            if(directedGraph.Edges != 1)
            {
                Assert.Fail();
            }
            directedGraph.RemoveEdge(new BaseEdge(0, 1, 1));
            if(directedGraph.Edges > 0)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void GetEdgesTest()
        {
            DirectedGraph directedGraph = new DirectedGraph(new MatrixRepresentation(5));
            for (int i = 0; i < 5; i++)
            {
                directedGraph.AddEdge(new BaseEdge(0, i, i));
            }
            if (directedGraph.GetEdges(new BaseNode(0)).Count != 5)
            {
                Assert.Fail();
            }
        }
    }
}
