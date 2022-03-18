
namespace Parking.Abstractions.Models
{
    public class GetRatesModel
    {
        public long Id { get; set; }

        public decimal CostPerHour { get; set; }

        public float Discount { get; set; }
    }
}
