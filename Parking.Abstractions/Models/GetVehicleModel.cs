
namespace Parking.Abstractions.Models
{
    public class GetVehicleModel
    {
        public long Id { get; set; }
        public string CarNumber { get; set; }
        public long PersonId { get; set; }
    }
}
