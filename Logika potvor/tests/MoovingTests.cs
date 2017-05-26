using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreatureTests
{
    [TestClass]
    public class MoovingTests
    {
        [TestMethod]
        public void TestMoovingChangeToDying()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            ICreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);
            Status mooving = creature.getMoovnig();
            Status dying = creature.getDying();

            int takenDamage = 100;
            creature.ReciveDamage(takenDamage);

            Assert.AreEqual(mooving.changeStatus(), dying);
        }

        [TestMethod]
        public void TestInitialStatus()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            ThinkingObject creatureThinkigObject = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);
            Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();

            Assert.AreEqual(creatureThinkigObject.presentStatus, mooving);
        }

        [TestMethod]
        public void TestPositionNull()
        {
            int damage = 10, hp = 100;

            try
            {
                ThinkingObject creatureThinkigObject = new BasicCreature(null, null, null, damage, hp, null);
                Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();
                mooving.onStart();
            }
            catch (NullReferenceException e)
            {
                StringAssert.Contains(e.Message, Mooving.NULL_POSITION);
            }
        }

        [TestMethod]
        public void TestDestinationNull()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;

            try
            {
                ThinkingObject creatureThinkigObject = new BasicCreature(startingNode, null, null, damage, hp, null);
                Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();
                mooving.onStart();
            }
            catch (NullReferenceException e)
            {
                StringAssert.Contains(e.Message, Mooving.NULL_DESTINATION);
            }
        }

        [TestMethod]
        public void TestGraphNull()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            Node finallDestination = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;

            try
            {
                ThinkingObject creatureThinkigObject = new BasicCreature(startingNode, finallDestination, null, damage, hp, null);
                Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();
                mooving.onStart();
            }
            catch (NullReferenceException e)
            {
                StringAssert.Contains(e.Message, Mooving.NULL_GRAPH);
            }
        }

        [TestMethod]
        public void TestPathFinder()
        {
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            System.Diagnostics.Debug.WriteLine(startDestinaton);

            BasicCreature creature = new BasicCreature(startDestinaton, finalDestination, graph, 100, 100, null);
            Mooving mooving = (Mooving)creature.getMoovnig();
            mooving.onStart();

            Node lastPosition = null;
            while (lastPosition != creature.getPosition())     //ked sa rovnaju posledny node a aktualny, znamena ze sa uz nehybem dalej
            {
                lastPosition = creature.getPosition();
                //najdi novu poziciu
                mooving.prepare();
                creature.action();
                System.Diagnostics.Debug.WriteLine(creature.getPosition());    //debug vypis noveho nodu
            }
            Assert.AreEqual(finalDestination, creature.getPosition());
        }
    }
}
