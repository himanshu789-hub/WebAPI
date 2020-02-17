using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolAPI.Enums
{
    public enum Address
    {
        RAIPUR=1,BOMABAY,CHENNAI,MADRAS,DELHI,LUCKNOW,AMRITSAR,BIHAR
    }

    public enum Discount
    {
     FIVE = 5 , TEN = 10 , TWENTY = 20
    }

    public enum BookingStatus
    {
     NOTREQUESTED,REQUESTED,ACCEPTED,REJECTED,DESTROYED,BROADCAST,CANCEL,COMPLETED
    }

    public enum AnounceStatus
    {
        APPROVED=1,COMMITTED,REJECTED,CLOSED,CANCELED
    }

    public enum BroadCastStatus
    {
        APPROVED=1,COMFIRMED=2,CLOSED=3
    }
    public enum VehicleType
    {
        MOPED=1,BIKE,HATCHBACK,SEDAN,SUV,OPEN_AIR,LIMO
    }
    
}
