using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Services
{
    public interface IVehicleService
    {
        public Task AddVehicleToPerson(string carNumber, long personId);

        public Task DeleteVehicle(string carNumber);

        public Task<GetVehicleModel> GetVehicle(string carNumber);

        public Task<IEnumerable<GetVehicleModel>> GetVehicles();
    }
}
