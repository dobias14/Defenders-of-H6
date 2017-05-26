using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace NodesTests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void TestInitialGraph()
        {
            int width = 5, height = 5;
            Graph graph = new Graph(width, height);

            Assert.AreEqual(graph.getWidth() , width);
            Assert.AreEqual(graph.getHeight(), height);
            Assert.AreEqual(graph.getNode[0,0].getId(), 0);
            Assert.AreEqual(graph.getDistance(), 10);
        }

        [TestMethod]
        public void TestFinalTargetGraph()
        {
            int width = 5, height = 5;
            Graph graph = new Graph(width, height);

            Assert.AreEqual(graph.getFinalTargetLocationId, 12);
        }

        [TestMethod]
        public void TestCreateEgeGraph()
        {
            int width = 2, height = 1;
            Graph graph = new Graph(width, height);

            graph.createEdge(graph.getNodes()[0,0],graph.getNodes()[0,1]);
               
            Assert.AreEqual(graph.getNodes()[0,0].getNeighbous.Count, 1);
            Assert.AreEqual(graph.getNodes()[0,1].getNeighbous.Count, 1);
        }

        [TestMethod]
        public void TestDisableEnableNodeGraph()
        {
            int width = 2, height = 1;
            Graph graph = new Graph(width, height);

            graph.createEdge(graph.getNodes()[0, 0], graph.getNodes()[0, 1]);

            graph.disableNode(0, 0);
            Assert.AreEqual(graph.getNodes()[0, 1].getNeighbous.Count, 0);

            graph.enableNode(0, 0);
            Assert.AreEqual(graph.getNodes()[0, 1].getNeighbous.Count, 1);
        }

    }
}
