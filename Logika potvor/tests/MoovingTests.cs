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
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            ICreature creature = new BasicCreature(startingNode, damage, hp);
            Status mooving = creature.getMoovnig();
            Status dying = creature.getDying();

            int takenDamage = 100;
            creature.ReciveDamage(takenDamage);

            Assert.AreEqual(mooving.changeStatus(), dying);
        }

        [TestMethod]
        public void TestInitialStatus()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            ThinkingObject creatureThinkigObject = new BasicCreature(startingNode, damage, hp);
            Status mooving = ((ICreature)creatureThinkigObject).getMoovnig();

            Assert.AreEqual(creatureThinkigObject.presentStatus , mooving);
        }
    }
}
