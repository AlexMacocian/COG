﻿using COG.Representations;
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
            listRepresentation.AddEdge(new Edge(1, 2, 5));
            listRepresentation.AddEdge(new Edge(3, 1, 5));
            if(listRepresentation.Edges != 2)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void RemoveEdgeTest()
        {
            ListRepresentation listRepresentation = new ListRepresentation(5);
            listRepresentation.AddEdge(new Edge(1, 2, 5));
            listRepresentation.AddEdge(new Edge(3, 1, 5));
            if (listRepresentation.Edges != 2)
            {
                Assert.Fail();
            }
            listRepresentation.RemoveEdge(new Edge(1, 2, 5));
            listRepresentation.RemoveEdge(new Edge(3, 1, 5));
            if(listRepresentation.Edges != 0)
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void GetEdgesTest()
        {
            ListRepresentation listRepresentation = new ListRepresentation(5);
            listRepresentation.AddEdge(new Edge(1, 2, 5));
            listRepresentation.AddEdge(new Edge(3, 1, 5));
            listRepresentation.AddEdge(new Edge(1, 3, 5));
            listRepresentation.AddEdge(new Edge(1, 4, 5));
            if(listRepresentation.GetEdges(1).Count != 3)
            {
                Assert.Fail();
            }
        }
    }
}
