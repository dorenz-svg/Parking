using System;

namespace Parking.DataAccess.SQL.Entities
{
    public class Dates
    {
        public long Id { get; set; }

        public DateTime DateArrival { get; set; }

        public DateTime? DateLeaving { get; set; }

        public long PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
