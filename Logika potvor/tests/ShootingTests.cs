using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreaturesTests
{
    [TestClass]
    public class ShootingTests
    {
        [TestMethod]
        public void TestShootingChangeToDying()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 100;
            ICreature creature = new BasicCreature(startingNode, damage, hp);
            Status shooting = creature.getShooting();
            Status dying = creature.getDying();

            int takenDamage = 100;
            creature.ReciveDamage(takenDamage);

            Assert.AreEqual(shooting.changeStatus(), dying);
        }
    }
}
