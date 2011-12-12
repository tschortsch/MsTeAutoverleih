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
        public void AutosTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Auto> autos = autoReservation.Autos;
            Assert.AreEqual(3, autos.Count);
        }

        [TestMethod]
        public void KundenTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Kunde> kunden = autoReservation.Kunden;
            Assert.AreEqual(4, kunden.Count);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Reservation> reservationen = autoReservation.Reservationen;
            Assert.AreEqual(1, reservationen.Count);
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Auto> autos = autoReservation.Autos;
            Auto first = autos[0];
            int id = first.Id;
            Auto autoById = autoReservation.GetAutoById(id);
            Assert.AreEqual(first, autoById);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Kunde> kunden = autoReservation.Kunden;
            Kunde first = kunden[0];
            int id = first.Id;
            Kunde kundeById = autoReservation.GetKundeById(id);
            Assert.AreEqual(first, kundeById);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Reservation> reservationen = autoReservation.Reservationen;
            Reservation first = reservationen[0];
            int nr = first.ReservationNr;
            Reservation reservationById = autoReservation.GetReservationByNr(nr);
            Assert.ReferenceEquals(first.AutoId, reservationById.AutoId);
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            Reservation reservationById = autoReservation.GetReservationByNr(9999999);
            Assert.IsNull(reservationById);
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            Auto auto = new StandardAuto();
            int count = autoReservation.Autos.Count;
            int id = 99999;
            auto.Id = id;
            auto.Marke = "Marke";
            autoReservation.InsertAuto(auto);
            Assert.AreEqual(count + 1, autoReservation.Autos.Count);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            int count = autoReservation.Kunden.Count;
            Kunde kunde = new Kunde();
            int id = 99999;
            kunde.Id = id;
            kunde.Nachname = "Nachname";
            kunde.Vorname = "Vorname";
            kunde.Geburtsdatum = System.DateTime.Today;
            autoReservation.InsertKunde(kunde);
            Assert.AreEqual(count + 1, autoReservation.Kunden.Count);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            int count = autoReservation.Reservationen.Count;
            Reservation reservation = new Reservation();
            int id = 99999;
            reservation.ReservationNr = id;
            reservation.Kunde = autoReservation.Kunden[0];
            reservation.Auto = autoReservation.Autos[0];
            reservation.Von = System.DateTime.Today;
            reservation.Bis = System.DateTime.Today;
            autoReservation.InsertReservation(reservation);
            Assert.AreEqual(count + 1, autoReservation.Reservationen.Count);
        }

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

        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Auto> autos = autoReservation.Autos;
            Auto original = autos[0];
            Auto modified = autos[0];
            Auto modified2 = autos[0];
            modified.Marke = "Test Marke";
            modified2.Marke = "Test Marke2";
            autoReservation.UpdateAuto(modified, original);
            try
            {
                autoReservation.UpdateAuto(modified2, original);
                Assert.Fail();
            }
            catch (LocalOptimisticConcurrencyException<Auto> ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Kunde> kunden = autoReservation.Kunden;
            Kunde original = kunden[0];
            Kunde modified = kunden[0];
            Kunde modified2 = kunden[0];
            modified.Nachname = "Test Nachname";
            modified2.Nachname = "Test Nachname2";
            autoReservation.UpdateKunde(modified, original);
            try
            {
                autoReservation.UpdateKunde(modified2, original);
                Assert.Fail();
            }
            catch (LocalOptimisticConcurrencyException<Kunde> ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            IList<Reservation> reservationen = autoReservation.Reservationen;
            Reservation original = reservationen[0];
            Reservation modified = reservationen[0];
            Reservation modified2 = reservationen[0];
            modified.Von = System.DateTime.Today;
            modified2.Von = new System.DateTime(12345678);
            autoReservation.UpdateReservation(modified, original);
            try
            {
                autoReservation.UpdateReservation(modified2, original);
                Assert.Fail();
            }
            catch (LocalOptimisticConcurrencyException<Reservation> ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            int count = autoReservation.Kunden.Count;
            Kunde delete = autoReservation.Kunden[0];
            int id = delete.Id;
            autoReservation.DeleteKunde(delete);
            Assert.AreEqual(count - 1, autoReservation.Kunden.Count);
            Assert.IsNull(autoReservation.GetKundeById(id));
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            int count = autoReservation.Autos.Count;
            Auto delete = autoReservation.Autos[0];
            int id = delete.Id;
            autoReservation.DeleteAuto(delete);
            Assert.AreEqual(count - 1, autoReservation.Autos.Count);
            Assert.IsNull(autoReservation.GetAutoById(id));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationBusinessComponent autoReservation = new AutoReservationBusinessComponent();
            int count = autoReservation.Reservationen.Count;
            Reservation delete = autoReservation.Reservationen[0];
            int nr = delete.ReservationNr;
            autoReservation.DeleteReservation(delete);
            Assert.AreEqual(count - 1, autoReservation.Reservationen.Count);
            Assert.IsNull(autoReservation.GetReservationByNr(nr));
        }
    }
}
