using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal;

namespace AutoReservation.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestMethod]
        public void AutosTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            IList<AutoDto> autos = service.Autos;
            Assert.AreEqual(3, autos.Count);
        }

        [TestMethod]
        public void KundenTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            IList<KundeDto> kunden = service.Kunden;
            Assert.AreEqual(4, kunden.Count);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            IList<ReservationDto> reservationen = service.Reservationen;
            Assert.AreEqual(1, reservationen.Count);
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            IList<AutoDto> autos = service.Autos;
            AutoDto first = autos[0];
            int id = first.Id;
            AutoDto autoById = service.GetAutoById(id);
            Assert.AreEqual(first, autoById);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            IList<KundeDto> kunden = service.Kunden;
            KundeDto first = kunden[0];
            int id = first.Id;
            KundeDto kundeById = service.GetKundeById(id);
            Assert.AreEqual(first, kundeById);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            IList<ReservationDto> reservationen = service.Reservationen;
            ReservationDto first = reservationen[0];
            int nr = first.ReservationNr;
            ReservationDto reservationById = service.GetReservationByNr(nr);
            Assert.AreEqual(first, reservationById);
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            ReservationDto reservationById = service.GetReservationByNr(9999999);
            Assert.IsNull(reservationById);
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            AutoDto auto = new AutoDto();
            int count = service.Autos.Count;
            int id = 99999;
            auto.Id = id;
            auto.Marke = "Marke";
            service.InsertAuto(auto);
            Assert.AreEqual(count + 1, service.Autos.Count);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            int count = service.Kunden.Count;
            KundeDto kunde = new KundeDto();
            int id = 99999;
            kunde.Id = id;
            kunde.Nachname = "Nachname";
            kunde.Vorname = "Vorname";
            kunde.Geburtsdatum = System.DateTime.Today;
            service.InsertKunde(kunde);
            Assert.AreEqual(count + 1, service.Kunden.Count);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            int count = service.Reservationen.Count;
            ReservationDto reservation = new ReservationDto();
            int id = 99999;
            reservation.ReservationNr = id;
            reservation.Kunde = service.Kunden[0];
            reservation.Auto = service.Autos[0];
            reservation.Von = System.DateTime.Today;
            reservation.Bis = System.DateTime.Today;
            service.InsertReservation(reservation);
            Assert.AreEqual(count + 1, service.Reservationen.Count);
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            AutoDto originalAuto = service.Autos[0];
            AutoDto modifiedAuto = (AutoDto)originalAuto.Clone();
            modifiedAuto.Marke = "Neue Marke";
            service.UpdateAuto(modifiedAuto, originalAuto);
            Assert.AreEqual(service.Autos[0], modifiedAuto);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            KundeDto originalKunde = service.Kunden[0];
            KundeDto modifiedKunde = (KundeDto)originalKunde.Clone();
            modifiedKunde.Nachname = "Neuer Nachname";
            service.UpdateKunde(modifiedKunde, originalKunde);
            Assert.AreEqual(service.Kunden[0], modifiedKunde);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            ReservationDto originalReservation = service.Reservationen[0];
            ReservationDto modifiedReservation = (ReservationDto)originalReservation.Clone();
            modifiedReservation.Von = System.DateTime.Today;
            service.UpdateReservation(modifiedReservation, originalReservation);
            Assert.AreEqual(service.Reservationen[0], modifiedReservation);
        }

        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            AutoDto originalAuto = service.Autos[0];
            AutoDto modifiedAuto = (AutoDto)originalAuto.Clone();
            AutoDto modifiedAuto2 = (AutoDto)originalAuto.Clone();
            modifiedAuto.Marke = "Neue Marke";
            modifiedAuto2.Marke = "Neue Marke2";
            service.UpdateAuto(modifiedAuto, originalAuto);
            try
            {
                service.UpdateAuto(modifiedAuto2, originalAuto);
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
            AutoReservationService service = new AutoReservationService();
            KundeDto originalKunde = service.Kunden[0];
            KundeDto modifiedKunde = (KundeDto)originalKunde.Clone();
            KundeDto modifiedKunde2 = (KundeDto)originalKunde.Clone();
            modifiedKunde.Nachname = "Neuer Nachname";
            modifiedKunde2.Nachname = "Neuer Nachname2";
            service.UpdateKunde(modifiedKunde, originalKunde);
            try
            {
                service.UpdateKunde(modifiedKunde2, originalKunde);
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
            AutoReservationService service = new AutoReservationService();
            ReservationDto originalReservation = service.Reservationen[0];
            ReservationDto modifiedReservation = (ReservationDto)originalReservation.Clone();
            ReservationDto modifiedReservation2 = (ReservationDto)originalReservation.Clone();
            modifiedReservation.Von = System.DateTime.Today;
            modifiedReservation2.Von = System.DateTime.Today;
            service.UpdateReservation(modifiedReservation, originalReservation);
            try
            {
                service.UpdateReservation(modifiedReservation2, originalReservation);
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
            AutoReservationService service = new AutoReservationService();
            int count = service.Kunden.Count;
            KundeDto delete = service.Kunden[0];
            int id = delete.Id;
            service.DeleteKunde(delete);
            Assert.AreEqual(count - 1, service.Kunden.Count);
            Assert.IsNull(service.GetKundeById(id));
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            int count = service.Autos.Count;
            AutoDto delete = service.Autos[0];
            int id = delete.Id;
            service.DeleteAuto(delete);
            Assert.AreEqual(count - 1, service.Autos.Count);
            Assert.IsNull(service.GetAutoById(id));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoReservationService service = new AutoReservationService();
            int count = service.Reservationen.Count;
            ReservationDto delete = service.Reservationen[0];
            int nr = delete.ReservationNr;
            service.DeleteReservation(delete);
            Assert.AreEqual(count - 1, service.Reservationen.Count);
            Assert.IsNull(service.GetReservationByNr(nr));
        }
    }
}
