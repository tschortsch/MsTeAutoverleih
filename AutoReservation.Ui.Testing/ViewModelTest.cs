using AutoReservation.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Ui.ViewModels;
using System.Windows.Input;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void AutosLoadTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            AutoViewModel viewmodel = new AutoViewModel();
            Assert.IsTrue(viewmodel.LoadCommand.CanExecute(null));
            Assert.AreEqual(3, viewmodel.Autos.Count);
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            KundeViewModel viewmodel = new KundeViewModel();
            Assert.IsTrue(viewmodel.LoadCommand.CanExecute(null));
            Assert.AreEqual(4, viewmodel.Kunden.Count);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            TestEnvironmentHelper.InitializeTestData();
            ReservationViewModel viewmodel = new ReservationViewModel();
            Assert.IsTrue(viewmodel.LoadCommand.CanExecute(null));
            Assert.AreEqual(1, viewmodel.Reservationen.Count);
        }
    }
}