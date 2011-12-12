using System;
using System.Diagnostics;
using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.BusinessLayer;
using System.ServiceModel;
using System.Collections.Generic;


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
        public IList<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                return autoReservation.Autos.ConvertToDtos();
            }
        }

        public AutoDto GetAutoById(int id)
        {
            WriteActualMethod();
            return autoReservation.GetAutoById(id).ConvertToDto();
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            autoReservation.DeleteAuto(auto.ConvertToEntity());
        }

        public void UpdateAuto(AutoDto modifiedAuto, AutoDto originalAuto)
        {
            WriteActualMethod();
            autoReservation.UpdateAuto(modifiedAuto.ConvertToEntity(), originalAuto.ConvertToEntity());
        }

        public void InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            autoReservation.InsertAuto(auto.ConvertToEntity());
        }

        // Reservation CRUD-Operationen
        public IList<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                return autoReservation.Reservationen.ConvertToDtos();
            }
        }

        public ReservationDto GetReservationByNr(int reservationNr)
        {
            WriteActualMethod();
            return autoReservation.GetReservationByNr(reservationNr).ConvertToDto();
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            autoReservation.DeleteReservation(reservation.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto modifiedReservation, ReservationDto originalReservation)
        {
            WriteActualMethod();
            autoReservation.UpdateReservation(modifiedReservation.ConvertToEntity(), originalReservation.ConvertToEntity());
        }

        public void InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            autoReservation.InsertReservation(reservation.ConvertToEntity());
        }

        // Kunde CRUD-Operationen
        public IList<KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                return autoReservation.Kunden.ConvertToDtos();
            }
        }

        public KundeDto GetKundeById(int id)
        {
            WriteActualMethod();
            return autoReservation.GetKundeById(id).ConvertToDto();
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            autoReservation.DeleteKunde(kunde.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto modifiedKunde, KundeDto originalKunde)
        {
            WriteActualMethod();
            autoReservation.UpdateKunde(modifiedKunde.ConvertToEntity(), originalKunde.ConvertToEntity());
        }

        public void InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            autoReservation.InsertKunde(kunde.ConvertToEntity());
        }
    }
}