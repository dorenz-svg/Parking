namespace Parking.Abstractions.Models
{
    public class CreatePaymentModel
    {
        public decimal Cost { get; set; }

        public long PersonId { get; set; }
    }
}
