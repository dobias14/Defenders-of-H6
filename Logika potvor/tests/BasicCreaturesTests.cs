using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreaturesTests
{
    [TestClass]
    public class BasicCreatureTests
    {
        [TestMethod]
        public void TestDead1()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            ICreature creature = new BasicCreature(startingNode, damage, hp);

            Assert.IsFalse(creature.isDead());
        }

        [TestMethod]
        public void TestDead2()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            ICreature creature = new BasicCreature(startingNode, damage, hp);

            int takenDamage = 100;
            creature.ReciveDamage(takenDamage);

            Assert.IsTrue(creature.isDead());
        }

        [TestMethod]
        public void TestDead3()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            ICreature creature = new BasicCreature(startingNode, damage, hp);

            int takenDamage = 120;
            creature.ReciveDamage(takenDamage);

            Assert.IsTrue(creature.isDead());
        }

        [TestMethod]
        public void TestHp()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            BasicCreature creature = new BasicCreature(startingNode, damage, hp);

            int takenDamage = 50;

            Assert.AreEqual(creature.ReciveDamage(takenDamage), (hp - takenDamage));
        }

        [TestMethod]
        public void TestHp2()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            BasicCreature creature = new BasicCreature(startingNode, damage, hp);

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
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            BasicCreature creature = new BasicCreature(startingNode, damage, hp);

            Node actualPosition = creature.Position;

            Assert.AreEqual(actualPosition, startingNode);
        }


    }
}
