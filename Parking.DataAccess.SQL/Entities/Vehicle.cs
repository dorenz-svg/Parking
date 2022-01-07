using System;
using System.Collections.Generic;

namespace Parking.DataAccess.SQL.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }

        public string CarNumber { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }

    }
}
