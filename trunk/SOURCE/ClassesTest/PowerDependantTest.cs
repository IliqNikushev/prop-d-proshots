using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public abstract class PowerDependantTest : UnitTest
    {
        [TestMethod]
        public abstract void OnPowerFailure();

        [TestMethod]
        public abstract void OnConnectionFailure();
    }
}
