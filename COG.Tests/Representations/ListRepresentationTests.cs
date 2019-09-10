using COG.Representations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace COG.Tests.Representations
{
    [TestClass]
    public class ListRepresentationTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            ListRepresentation listRepresentation = new ListRepresentation(5);
            if(listRepresentation.Nodes != 5)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void AddEdgeTest()
        {
            ListRepresentation listRepresentation = new ListRepresentation(5);
            listRepresentation.AddEdge(new BaseEdge(1, 2, 5));
            listRepresentation.AddEdge(new BaseEdge(3, 1, 5));
            if(listRepresentation.Edges != 2)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void RemoveEdgeTest()
        {
            ListRepresentation listRepresentation = new ListRepresentation(5);
            listRepresentation.AddEdge(new BaseEdge(1, 2, 5));
            listRepresentation.AddEdge(new BaseEdge(3, 1, 5));
            if (listRepresentation.Edges != 2)
            {
                Assert.Fail();
            }
            listRepresentation.RemoveEdge(new BaseEdge(1, 2, 5));
            listRepresentation.RemoveEdge(new BaseEdge(3, 1, 5));
            if(listRepresentation.Edges != 0)
            {
                Assert.Fail();
            }
        }
    }
}
