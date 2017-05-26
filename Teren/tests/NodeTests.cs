using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace NodesTests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void TestInitialNode()
        {
            int id = 0, x = 0, y = 0, terrain = 0;
            Node node = new Node(id,x,y,terrain);

            Assert.AreEqual(node.getId() , id);
            Assert.AreEqual(node.getX(), x);
            Assert.AreEqual(node.getY(), y);
            Assert.AreEqual(node.getTerrain(), terrain);
        }

        [TestMethod]
        public void TestSetTerrainNode()
        {
            int id = 0, x = 0, y = 0, terrain = 0;
            Node node = new Node(id, x, y, terrain);
            node.setTerrain(10);
            Assert.AreEqual(node.getTerrain(), 10);
        }

        [TestMethod]
        public void TestAddRemoveEdgeNode()
        {
            int id = 0, x = 0, y = 0, terrain = 0;
            Node node = new Node(id, x, y, terrain);

            int id2 = 1, x2 = 0, y2 = 0, terrain2 = 1;
            Node node2 = new Node(id2, x2, y2, terrain2);

            node.addEdge(node2);

            Assert.AreEqual(node.getNeighbours().Count, 1);

            node.removeEdgeTo(node2);


            Assert.AreEqual(node.getNeighbour().Count, 0);
        }

        [TestMethod]
        public void TestEnableNode()
        {
            int id = 0, x = 0, y = 0, terrain = 0;
            Node node = new Node(id, x, y, terrain);

            int id2 = 1, x2 = 0, y2 = 0, terrain2 = 3;
            Node node2 = new Node(id2, x2, y2, terrain2);

            Assert.IsTrue(node.isEnable());
            Assert.IsFalse(node2.isEnable());
        }

    }
}
