using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreaturesTests
{
    [TestClass]
    public class MoovingTests
    {
        [TestMethod]
        public void TestMoovingChangeToDying()
        {
            int damage = 10, hp = 100;
            ICreature creature = new BasicCreature(null, null, null, damage, hp, null);
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
            ThinkingObject creatureThinkigObject = new BasicCreature(null, null, null, damage, hp, null);
            Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();

            Assert.AreEqual(creatureThinkigObject.presentStatus , mooving);
        }

        [TestMethod]
        public void TestPositionNull()
        {
            int damage = 10, hp = 100;
            ThinkingObject creatureThinkigObject = new BasicCreature(null, null, null, damage, hp, null);
            Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();

            try
            {
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
            ThinkingObject creatureThinkigObject = new BasicCreature(startingNode, null, null, damage, hp, null);
            Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();

            try
            {
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
            ThinkingObject creatureThinkigObject = new BasicCreature(startingNode, finallDestination, null, damage, hp, null);
            Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();

            try
            {
                mooving.onStart();
            }
            catch (NullReferenceException e)
            {
                StringAssert.Contains(e.Message, Mooving.NULL_GRAPH);
            }
        }

       
    }
}
