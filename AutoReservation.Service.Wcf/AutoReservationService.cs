using System;
using System.Diagnostics;
using AutoReservation.Common.Interfaces;
using AutoReservation.BusinessLayer;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class AutoReservationService : IAutoReservationService
    {
        private AutoReservationBusinessComponent autoReservation;

        public AutoReservationService()
        {
            autoReservation = new AutoReservationBusinessComponent();
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        // Auto CRUD-Operationen
        public System.Collections.Generic.IList<Common.DataTransferObjects.AutoDto> GetAutos()
        {
            WriteActualMethod();
            return autoReservation.GetAutos().ConvertToDtos();
        }

        public Common.DataTransferObjects.AutoDto GetAutoById(int id)
        {
            WriteActualMethod();
            return autoReservation.GetAutoById(id).ConvertToDto();
        }

        public void DeleteAuto(Common.DataTransferObjects.AutoDto auto)
        {
            WriteActualMethod();
            autoReservation.DeleteAuto(auto.ConvertToEntity());
        }

        public void UpdateAuto(Common.DataTransferObjects.AutoDto originalAuto, Common.DataTransferObjects.AutoDto modifiedAuto)
        {
            WriteActualMethod();
            autoReservation.UpdateAuto(originalAuto.ConvertToEntity(), modifiedAuto.ConvertToEntity());
        }

        public void AddAuto(Common.DataTransferObjects.AutoDto auto)
        {
            WriteActualMethod();
            autoReservation.AddAuto(auto.ConvertToEntity());
        }

        // Reservation CRUD-Operationen
        public System.Collections.Generic.IList<Common.DataTransferObjects.ReservationDto> GetReservationen()
        {
            WriteActualMethod();
            return autoReservation.GetReservationen().ConvertToDtos();
        }

        public Common.DataTransferObjects.ReservationDto GetReservationById(int reservationNr)
        {
            WriteActualMethod();
            return autoReservation.GetReservationById(reservationNr).ConvertToDto();
        }

        public void DeleteReservation(Common.DataTransferObjects.ReservationDto reservation)
        {
            WriteActualMethod();
            autoReservation.DeleteReservation(reservation.ConvertToEntity());
        }

        public void UpdateReservation(Common.DataTransferObjects.ReservationDto originalReservation, Common.DataTransferObjects.ReservationDto modifiedReservation)
        {
            WriteActualMethod();
            autoReservation.UpdateReservation(originalReservation.ConvertToEntity(), modifiedReservation.ConvertToEntity());
        }

        public void AddReservation(Common.DataTransferObjects.ReservationDto reservation)
        {
            WriteActualMethod();
            autoReservation.AddReservation(reservation.ConvertToEntity());
        }

        // Kunde CRUD-Operationen
        public System.Collections.Generic.IList<Common.DataTransferObjects.KundeDto> GetKunden()
        {
            WriteActualMethod();
            return autoReservation.GetKunden().ConvertToDtos();
        }

        public Common.DataTransferObjects.KundeDto GetKundeById(int id)
        {
            WriteActualMethod();
            return autoReservation.GetKundeById(id).ConvertToDto();
        }

        public void DeleteKunde(Common.DataTransferObjects.KundeDto kunde)
        {
            WriteActualMethod();
            autoReservation.DeleteKunde(kunde.ConvertToEntity());
        }

        public void UpdateKunde(Common.DataTransferObjects.KundeDto originalKunde, Common.DataTransferObjects.KundeDto modifiedKunde)
        {
            WriteActualMethod();
            autoReservation.UpdateKunde(originalKunde.ConvertToEntity(), modifiedKunde.ConvertToEntity());
        }

        public void AddKunde(Common.DataTransferObjects.KundeDto kunde)
        {
            WriteActualMethod();
            autoReservation.AddKunde(kunde.ConvertToEntity());
        }
    }
}