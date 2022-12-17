using System;

namespace Parking.DataAccess.SQL.Entities
{
    public class Dates
    {
        public long Id { get; set; }
        /// <summary>
        /// время приезда
        /// </summary>
        public DateTime DateArrival { get; set; }
        /// <summary>
        /// время отъезда
        /// </summary>
        public DateTime? DateLeaving { get; set; }

        public long PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
