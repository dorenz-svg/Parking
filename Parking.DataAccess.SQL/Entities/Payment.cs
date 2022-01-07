using System;

namespace Parking.DataAccess.SQL.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }

        public decimal Cost { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }
    }
}
