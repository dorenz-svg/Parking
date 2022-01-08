namespace Parking.Abstractions.Models
{
    public class GetPaymentModel
    {
        public string Id { get; set; }

        public decimal Cost { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
