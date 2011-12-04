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
        public System.Collections.Generic.IList<Common.DataTransferObjects.AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                return autoReservation.Autos.ConvertToDtos();
            }
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

        public void UpdateAuto(Common.DataTransferObjects.AutoDto modifiedAuto, Common.DataTransferObjects.AutoDto originalAuto)
        {
            WriteActualMethod();
            autoReservation.UpdateAuto(modifiedAuto.ConvertToEntity(), originalAuto.ConvertToEntity());
        }

        public void InsertAuto(Common.DataTransferObjects.AutoDto auto)
        {
            WriteActualMethod();
            autoReservation.InsertAuto(auto.ConvertToEntity());
        }

        // Reservation CRUD-Operationen
        public System.Collections.Generic.IList<Common.DataTransferObjects.ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                return autoReservation.Reservationen.ConvertToDtos();
            }
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

        public void UpdateReservation(Common.DataTransferObjects.ReservationDto modifiedReservation, Common.DataTransferObjects.ReservationDto originalReservation)
        {
            WriteActualMethod();
            autoReservation.UpdateReservation(modifiedReservation.ConvertToEntity(), originalReservation.ConvertToEntity());
        }

        public void InsertReservation(Common.DataTransferObjects.ReservationDto reservation)
        {
            WriteActualMethod();
            autoReservation.InsertReservation(reservation.ConvertToEntity());
        }

        // Kunde CRUD-Operationen
        public System.Collections.Generic.IList<Common.DataTransferObjects.KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                return autoReservation.Kunden.ConvertToDtos();
            }
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

        public void UpdateKunde(Common.DataTransferObjects.KundeDto modifiedKunde, Common.DataTransferObjects.KundeDto originalKunde)
        {
            WriteActualMethod();
            autoReservation.UpdateKunde(modifiedKunde.ConvertToEntity(), originalKunde.ConvertToEntity());
        }

        public void InsertKunde(Common.DataTransferObjects.KundeDto kunde)
        {
            WriteActualMethod();
            autoReservation.InsertKunde(kunde.ConvertToEntity());
        }
    }
}