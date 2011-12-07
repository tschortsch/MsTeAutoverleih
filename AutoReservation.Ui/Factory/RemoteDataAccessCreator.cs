using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;
using System.ServiceModel;

namespace AutoReservation.Ui.Factory
{
    public class RemoteDataAccessCreator : Creator
    {
        public override IAutoReservationService CreateBusinessLayerInstance()
        {
            ChannelFactory<IAutoReservationService> factory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
            IAutoReservationService proxy = factory.CreateChannel();
            return proxy;
        }
    }
}
