using System;

namespace Parking.DataAccess.SQL.Entities
{
    public class Payment
    {
        public long Id { get; set; }

        public decimal Cost { get; set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}
