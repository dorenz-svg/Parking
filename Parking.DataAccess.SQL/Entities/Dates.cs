using System;

namespace Parking.DataAccess.SQL.Entities
{
    public class Dates
    {
        public Guid Id { get; set; }

        public DateTime DateArrival { get; set; }

        public DateTime? DateLeaving { get; set; }

        public Guid PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
