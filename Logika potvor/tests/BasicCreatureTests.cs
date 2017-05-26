using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreatureTests
{
    [TestClass]
    public class BasicCreatureTests
    {
        [TestMethod]
        public void TestDead1()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            ICreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);

            Assert.IsFalse(creature.isDead());
        }

        [TestMethod]
        public void TestDead2()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            ICreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);

            int takenDamage = 100;
            creature.ReciveDamage(takenDamage);

            Assert.IsTrue(creature.isDead());
        }

        [TestMethod]
        public void TestDead3()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            ICreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);

            int takenDamage = 120;
            creature.ReciveDamage(takenDamage);

            Assert.IsTrue(creature.isDead());
        }

        [TestMethod]
        public void TestHp()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            BasicCreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);

            int takenDamage = 50;

            Assert.AreEqual(creature.ReciveDamage(takenDamage), (hp - takenDamage));
        }

        [TestMethod]
        public void TestHp2()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            BasicCreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);

            try
            {
                int takenDamage = -50;
                creature.ReciveDamage(takenDamage);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BasicCreature.NEGATIVE_DAMAGE);
            }
        }


        [TestMethod]
        public void Node()
        {
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            int damage = 10, hp = 100;
            BasicCreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);

            Node actualPosition = creature.Position;

            Assert.AreEqual(actualPosition, startDestinaton);
        }
    }
}
