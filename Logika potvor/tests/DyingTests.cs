﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DefendersOfH6;

namespace CreatureTests
{
    [TestClass]
    public class DyingTests
    {
        [TestMethod]
        public void TestDyingNotChageStatus()
        {
            Status dying = new Dying(null);

            Assert.AreEqual(dying.changeStatus(), null);
        }
    }
}
