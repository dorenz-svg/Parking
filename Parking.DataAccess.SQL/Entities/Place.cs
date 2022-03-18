using System;
using System.Collections.Generic;

namespace Parking.DataAccess.SQL.Entities
{
    public class Place
    {
        public long Id { get; set; }

        public long? PersonId { get; set; }

        public Person Person { get; set; }

        public long IdRates { get; set; }

        public Rates Rates { get; set; }

        public IEnumerable<Dates> Dates { get; set; }
    }
}
