using System;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AutoReservation.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {

        [TestMethod]
        public void UpdateAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            Auto originalAuto = autoReservation.GetAutoById(1);
            Auto modifiedAuto = autoReservation.GetAutoById(1);
            modifiedAuto.Marke = "Neue Marke";
            autoReservation.UpdateAuto(originalAuto, modifiedAuto);
            Assert.AreEqual(autoReservation.GetAutoById(1), modifiedAuto);
        }
        [TestMethod]
        public void GetAllAutosTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Auto> autos = autoReservation.Autos;

            IList<string> autoMarkenOriginal = new List<string>();
            autoMarkenOriginal.Add("Fiat Punto");
            autoMarkenOriginal.Add("VW Golf");
            autoMarkenOriginal.Add("Audi S6");
            IList<string> autoMarken = new List<string>();

            foreach (Auto auto in autos)
            {
                autoMarken.Add(auto.Marke);
            }
            Assert.AreEqual(autoMarkenOriginal, autoMarken);
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
