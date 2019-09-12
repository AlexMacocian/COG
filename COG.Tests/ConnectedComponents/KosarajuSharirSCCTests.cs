using COG.ConectedComponents;
using COG.Graphs;
using COG.Representations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace COG.Tests.ConnectedComponents
{
    [TestClass]
    public class KosarajuSharirSCCTests
    {
        [TestMethod]
        public void SolveTest()
        {
            string[] lines = File.ReadAllLines("SCCTestGraph.txt");
            int n = int.Parse(lines[0].Split(' ')[0]);
            int m = int.Parse(lines[0].Split(' ')[1]);
            int conCount = int.Parse(lines[lines.Length - 1]);
            DirectedGraph graph = new DirectedGraph(new MatrixRepresentation(n));
            for (int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                graph.AddEdge(new Edge(from, to, 1));
            }
            graph.ConnectedComponentsSolver = new KosarajuSharirSCC();
            var components = graph.GetConnectedComponents();
            if(components.Count != conCount)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SolveTest2()
        {
            string[] lines = File.ReadAllLines("SCCTestGraph2.txt");
            int n = int.Parse(lines[0].Split(' ')[0]);
            int m = int.Parse(lines[0].Split(' ')[1]);
            int conCount = int.Parse(lines[lines.Length - 1]);
            DirectedGraph graph = new DirectedGraph(new MatrixRepresentation(n));
            for (int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                graph.AddEdge(new Edge(from, to, 1));
            }
            graph.ConnectedComponentsSolver = new KosarajuSharirSCC();
            var components = graph.GetConnectedComponents();
            if (components.Count != conCount)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SolveTest3()
        {
            string[] lines = File.ReadAllLines("MSTTestGraph.txt");
            int n = int.Parse(lines[0].Split(' ')[0]);
            int m = int.Parse(lines[0].Split(' ')[1]);
            int conCount = int.Parse(lines[lines.Length - 1]);
            UndirectedGraph graph = new UndirectedGraph(new MatrixRepresentation(n));
            for (int i = 0; i < m; i++)
            {
                string[] tokens = lines[i + 1].Split(' ');
                int from = int.Parse(tokens[0]);
                int to = int.Parse(tokens[1]);
                graph.AddEdge(new Edge(from, to, 1));
            }
            graph.ConnectedComponentsSolver = new KosarajuSharirSCC();
            var components = graph.GetConnectedComponents();
            if (components.Count != 1)
            {
                Assert.Fail();
            }
        }
    }
}
