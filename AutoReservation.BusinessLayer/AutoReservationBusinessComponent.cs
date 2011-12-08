using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Dal;
using System.Data;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {       
        /*
        * Auto CRUD-Operationen
        */
        public IList<Auto> Autos
        {
            get
            {
                using (AutoReservationEntities context = new AutoReservationEntities())
                {
                    var autos = from a in context.Autos select a;
                    return autos.ToList();
                }
            }
        }

        public Auto GetAutoById(int id)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                var auto = from a in context.Autos
                           where a.Id == id
                           select a;
                return auto.FirstOrDefault();
            }
        }

        public void DeleteAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Autos.Attach(auto);
                context.Autos.DeleteObject(auto);
                context.SaveChanges();
            }
        }

        public void UpdateAuto(Auto modifiedAuto, Auto originalAuto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
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
        }

        public void InsertAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToAutos(auto);
                context.SaveChanges();
            }
        }

        /*
         * Reservation CRUD-Operationen
         */
        public IList<Reservation> Reservationen
        {
            get
            {
                using (AutoReservationEntities context = new AutoReservationEntities())
                {
                    var reservationen = from r in context.Reservationen select r;
                    return reservationen.ToList();
                }
            }
        }

        public Reservation GetReservationById(int reservationNr)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                var reservation = from r in context.Reservationen
                                  where r.ReservationNr == reservationNr
                                  select r;
                return reservation.FirstOrDefault();
            }
        }

        public void DeleteReservation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Reservationen.Attach(reservation);
                context.Reservationen.DeleteObject(reservation);
                context.SaveChanges();
            }
        }

        public void UpdateReservation(Reservation modifiedReservation, Reservation originalReservation)
        {
            try
            {
                using (AutoReservationEntities context = new AutoReservationEntities())
                {
                    context.Reservationen.Attach(originalReservation);
                    context.Reservationen.ApplyCurrentValues(modifiedReservation);
                    context.SaveChanges();
                }
            }
            catch (OptimisticConcurrencyException)
            {
                throw new LocalOptimisticConcurrencyException<Kunde>("Reservation wurde bereits verändert.");
            }
        }

        public void InsertReservation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToReservationen(reservation);
                context.SaveChanges();
            }
        }

        /*
         * Kunde CRUD-Operationen
         */
        public IList<Kunde> Kunden
        {
            get
            {
                using (AutoReservationEntities context = new AutoReservationEntities())
                {
                    var kunden = from k in context.Kunden select k;
                    return kunden.ToList();
                }
            }
        }

        public Kunde GetKundeById(int id)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                var kunde = from k in context.Kunden
                            where k.Id == id
                            select k;
                return kunde.FirstOrDefault();
            }
        }

        public void DeleteKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Kunden.Attach(kunde);
                context.Kunden.DeleteObject(kunde);
                context.SaveChanges();
            }
        }

        public void UpdateKunde(Kunde modifiedKunde, Kunde originalKunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
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
        }

        public void InsertKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.AddToKunden(kunde);
                context.SaveChanges();
            }
        }
    }
}
