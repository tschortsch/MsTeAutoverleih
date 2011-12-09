using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AutoReservation.Service.Wcf;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {

        [TestMethod]
        public void UpdateAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

    }
}
