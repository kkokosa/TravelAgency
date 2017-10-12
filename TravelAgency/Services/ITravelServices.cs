using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebLearn1.Services
{
    [ServiceContract(Namespace = "bankruptTravel.com.TravelServices")]
    public interface ITravelServices
    {
        [OperationContract]
        GetTripsResponse GetTrips(GetTripsRequest request);

        [OperationContract]
        GetToursResponse GetTours(GetToursRequest request);
    }
}
