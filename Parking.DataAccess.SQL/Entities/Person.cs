using System;
using System.Collections.Generic;

namespace Parking.DataAccess.SQL.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Phone { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }

        public IEnumerable<Place> Places { get; set; }

        public IEnumerable<Payment> Payments { get; set; }
    }
}
