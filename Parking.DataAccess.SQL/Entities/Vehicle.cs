using System;
using System.Collections.Generic;

namespace Parking.DataAccess.SQL.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }

        public string CarBrand { get; set; }

        public Guid IdPerson { get; set; }

        public Person Person { get; set; }

        public IEnumerable<Place> Places { get; set; }
    }
}
