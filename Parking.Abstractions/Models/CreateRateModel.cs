namespace Parking.Abstractions.Models
{
    public class CreateRateModel
    {
        public decimal CostPerHour { get; set; }

        public float Discount { get; set; }
    }
}
