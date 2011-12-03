using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Dal;
using System.Data;

namespace AutoReservation.BusinessLayer
{
    class AutoReservationBusinessComponent
    {
        private AutoReservationEntities context;

        public AutoReservationBusinessComponent()
        {
            context = new AutoReservationEntities();
        }

        /*
        * Auto CRUD-Operationen
        */
        public IList<Auto> GetAutos()
        {
            var autos = from a in context.Autos select a;
            return autos.ToList();
        }

        public Auto GetAutoById(int id)
        {
            var auto = from a in context.Autos
                        where a.Id == id
                        select a;
            return auto.FirstOrDefault();
        }

        public void DeleteAuto(Auto auto)
        {
            context.Autos.Attach(auto);
            context.Autos.DeleteObject(auto);
            context.SaveChanges();
        }

        public void UpdateAuto(Auto originalAuto, Auto modifiedAuto)
        {
            try
            {
                context.Autos.Attach(originalAuto);
                context.Autos.ApplyCurrentValues(modifiedAuto);
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                throw new LocalOptimisticConcurrencyException<Kunde>("Auto wurde bereits verändert.");
            }
        }

        public void AddAuto(Auto auto)
        {
            context.AddToAutos(auto);
            context.SaveChanges();
        }

        /*
         * Reservation CRUD-Operationen
         */
        public IList<Reservation> GetReservationen()
        {
            var reservationen = from r in context.Reservationen select r;
            return reservationen.ToList();
        }

        public Reservation GetReservationById(int reservationNr)
        {
            var reservation = from r in context.Reservationen
                              where r.ReservationNr == reservationNr
                              select r;
            return reservation.FirstOrDefault();
        }

        public void DeleteReservation(Reservation reservation)
        {
            context.Reservationen.Attach(reservation);
            context.Reservationen.DeleteObject(reservation);
            context.SaveChanges();
        }

        public void UpdateReservation(Reservation originalReservation, Reservation modifiedReservation)
        {
            try
            {
                context.Reservationen.Attach(originalReservation);
                context.Reservationen.ApplyCurrentValues(modifiedReservation);
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                throw new LocalOptimisticConcurrencyException<Kunde>("Reservation wurde bereits verändert.");
            }
        }

        public void AddReservation(Reservation reservation)
        {
            context.AddToReservationen(reservation);
            context.SaveChanges();
        }

        /*
         * Kunde CRUD-Operationen
         */
        public IList<Kunde> GetKunden()
        {
            var kunden = from k in context.Kunden select k;
            return kunden.ToList();
        }

        public Kunde GetKundeById(int id)
        {
            var kunde = from k in context.Kunden
                              where k.Id == id
                              select k;
            return kunde.FirstOrDefault();
        }

        public void DeleteKunde(Kunde kunde)
        {
            context.Kunden.Attach(kunde);
            context.Kunden.DeleteObject(kunde);
            context.SaveChanges();
        }

        public void UpdateKunde(Kunde originalKunde, Kunde modifiedKunde)
        {
            try
            {
                context.Kunden.Attach(originalKunde);
                context.Kunden.ApplyCurrentValues(modifiedKunde);
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
                throw new LocalOptimisticConcurrencyException<Kunde>("Kunde wurde bereits verändert.");
            }
        }

        public void AddKunde(Kunde kunde)
        {
            context.AddToKunden(kunde);
            context.SaveChanges();
        }
    }
}
