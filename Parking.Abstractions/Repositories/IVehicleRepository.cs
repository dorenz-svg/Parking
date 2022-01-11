using Parking.Abstractions.Models;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IVehicleRepository
    {
        public Task AddVehicleToPerson(string carNumber, string personId);
        public Task DeleteVehicle(string carNumber);
        public Task<GetVehicleModel> GetVehicle(string carNumber);
    }
}
