using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreaturesTests
{
    [TestClass]
    public class DyingTests
    {
        [TestMethod]
        public void TestDyingNotChageStatus()
        {
            int x = 0, y = 0, id = 0, terrain = 0;
            Node startingNode = new Node(id, x, y, terrain);
            int damage = 10, hp = 0;
            ICreature creature = new BasicCreature(startingNode, damage, hp);
            Status mooving = creature.getMoovnig();
            Status dying = creature.getDying();

            
            mooving.changeStatus(); //change status to do dying

            Assert.AreEqual(dying.changeStatus(), null);
        }
    }
}
