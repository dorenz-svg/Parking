using System;
using System.Collections.Generic;

namespace Parking.DataAccess.SQL.Entities
{
    public class Rates
    {
        public long Id { get; set; }

        public decimal CostPerHour { get; set; }

        public float Discount { get; set; }

        public IEnumerable<Place> Places { get; set; }
    }
}
