using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        // Auto CRUD-Operationen
        IList<AutoDto> Autos { [OperationContract] get; }
        [OperationContract]
        AutoDto GetAutoById(int id);
        [OperationContract]
        void DeleteAuto(AutoDto auto);
        [OperationContract]
        void UpdateAuto(AutoDto modifiedAuto, AutoDto originalAuto);
        [OperationContract]
        void InsertAuto(AutoDto auto);

        // Reservation CRUD-Operationen
        IList<ReservationDto> Reservationen { [OperationContract] get; }
        [OperationContract]
        ReservationDto GetReservationByNr(int reservationNr);
        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
        [OperationContract]
        void UpdateReservation(ReservationDto modifiedReservation, ReservationDto originalReservation);
        [OperationContract]
        void InsertReservation(ReservationDto reservation);

        // Kunde CRUD-Operationen
        IList<KundeDto> Kunden { [OperationContract] get; }
        [OperationContract]
        KundeDto GetKundeById(int id);
        [OperationContract]
        void DeleteKunde(KundeDto kunde);
        [OperationContract]
        void UpdateKunde(KundeDto modifiedKunde, KundeDto originalKunde);
        [OperationContract]
        void InsertKunde(KundeDto kunde);
    }
}
