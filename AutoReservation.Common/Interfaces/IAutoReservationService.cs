using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    interface IAutoReservationService
    {
        // Auto CRUD-Operationen
        [OperationContract]
        IList<AutoDto> GetAutos();
        [OperationContract]
        AutoDto GetAutoById(int id);
        [OperationContract]
        void DeleteAuto(AutoDto auto);
        [OperationContract]
        void UpdateAuto(AutoDto originalAuto, AutoDto modifiedAuto);
        [OperationContract]
        void AddAuto(AutoDto auto);

        // Reservation CRUD-Operationen
        [OperationContract]
        IList<ReservationDto> GetReservationen();
        [OperationContract]
        ReservationDto GetReservationById(int reservationNr);
        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
        [OperationContract]
        void UpdateReservation(ReservationDto originalReservation, ReservationDto modifiedReservation);
        [OperationContract]
        void AddReservation(ReservationDto reservation);

        // Kunde CRUD-Operationen
        [OperationContract]
        IList<KundeDto> GetKunden();
        [OperationContract]
        KundeDto GetKundeById(int id);
        [OperationContract]
        void DeleteKunde(KundeDto kunde);
        [OperationContract]
        void UpdateKunde(KundeDto originalKunde, KundeDto modifiedKunde);
        [OperationContract]
        void AddKunde(KundeDto kunde);
    }
}
