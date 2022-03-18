using System;
using System.Collections.Generic;

namespace Parking.DataAccess.SQL.Entities
{
    public class Vehicle
    {
        public long Id { get; set; }

        public string CarNumber { get; set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }

    }
}
