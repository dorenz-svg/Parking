using System;
using System.Collections.Generic;

namespace Parking.DataAccess.SQL.Entities
{
    public class Place
    {
        public Guid Id { get; set; }

        public Guid IdVehicle { get; set; }

        public Vehicle Vehicle { get; set; }

        public Guid IdPerson { get; set; }

        public Person Person { get; set; }

        public Guid IdRates { get; set; }

        public Rates Rates { get; set; }

        public IEnumerable<Dates> Dates { get; set; }
    }
}
