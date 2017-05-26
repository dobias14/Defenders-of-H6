using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreatureTests
{
    [TestClass]
    public class ShootingTests
    {
        [TestMethod]
        public void TestShootingChangeToDying()
        {
            int damage = 10, hp = 100;
            Graph graph = new Graph(10, 10);
            Node startDestinaton = graph.getNode(1, 1);
            Node finalDestination = graph.getNode(5, 5);
            ICreature creature = new BasicCreature(startDestinaton, finalDestination, graph, damage, hp, null);
            Status shooting = creature.getShooting();
            Status dying = creature.getDying();

            int takenDamage = 100;
            creature.ReciveDamage(takenDamage);

            Assert.AreEqual(shooting.changeStatus(), dying);
        }
    }
}
