using COG.Representations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Tests.Representations
{
    [TestClass]
    public class WeightedMatrixRepresentationTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            WeightedMatrixRepresentation listRepresentation = new WeightedMatrixRepresentation(5);
            if (listRepresentation.Nodes != 5)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void AddEdgeTest()
        {
            WeightedMatrixRepresentation listRepresentation = new WeightedMatrixRepresentation(5);
            listRepresentation.AddEdge(new Edge(1, 2, 5));
            listRepresentation.AddEdge(new Edge(3, 1, 5));
            if (listRepresentation.Edges != 2)
            {
                Assert.Fail();
            }
            if (listRepresentation.GetEdges(1)[0].Cost != 5)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void RemoveEdgeTest()
        {
            WeightedMatrixRepresentation listRepresentation = new WeightedMatrixRepresentation(5);
            listRepresentation.AddEdge(new Edge(1, 2, 5));
            listRepresentation.AddEdge(new Edge(3, 1, 5));
            if (listRepresentation.Edges != 2)
            {
                Assert.Fail();
            }
            listRepresentation.RemoveEdge(new Edge(1, 2, 5));
            listRepresentation.RemoveEdge(new Edge(3, 1, 5));
            if (listRepresentation.Edges != 0)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void GetEdgesTest()
        {
            WeightedMatrixRepresentation listRepresentation = new WeightedMatrixRepresentation(5);
            listRepresentation.AddEdge(new Edge(1, 2, 5));
            listRepresentation.AddEdge(new Edge(3, 1, 5));
            listRepresentation.AddEdge(new Edge(1, 3, 5));
            listRepresentation.AddEdge(new Edge(1, 4, 5));
            if (listRepresentation.GetEdges(1).Count != 3)
            {
                Assert.Fail();
            }
            foreach (Edge baseEdge in listRepresentation.GetEdges(1))
            {
                if (baseEdge.Cost != 5)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
