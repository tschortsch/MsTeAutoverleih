using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;

namespace AutoReservation.Ui.Factory
{
    public class LocalDataAccessCreator : Creator
    {
        public override IAutoReservationService CreateBusinessLayerInstance()
        {
            // TODO return local service instance
            return new AutoReservationService();
        }
    }
}
