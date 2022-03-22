using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IVehicleRepository
    {
        public Task AddVehicleToPerson(string carNumber, long personId);
        public Task DeleteVehicle(string carNumber);
        public Task<GetVehicleModel> GetVehicle(string carNumber);
        public Task<IEnumerable<GetVehicleModel>> GetVehicles();
    }
}
