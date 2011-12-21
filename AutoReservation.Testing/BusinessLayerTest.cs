using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal;

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
            IList<Auto> autos = autoReservation.Autos;
            Auto original = autos[0];
            Auto modified = autos[0];
            modified.Marke = "Test Marke";
            autoReservation.UpdateAuto(modified, original);
            Auto modifiedAgain = autos[0];
            Assert.AreEqual(modified, modifiedAgain);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Kunde> kunden = autoReservation.Kunden;
            Kunde original = kunden[0];
            Kunde modified = kunden[0];
            modified.Vorname = "Test Vorname";
            autoReservation.UpdateKunde(modified, original);
            Kunde modifiedAgain = kunden[0];
            Assert.AreEqual(modified, modifiedAgain);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Reservation> reservationen = autoReservation.Reservationen;
            Reservation original = reservationen[0];
            Reservation modified = reservationen[0];
            modified.Bis = System.DateTime.Today;
            autoReservation.UpdateReservation(modified, original);
            Reservation modifiedAgain = reservationen[0];
            Assert.AreEqual(modified, modifiedAgain);
        }

    }
}
