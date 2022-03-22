using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task AddVehicleToPerson(string carBrand, long personId)
        {
            await _vehicleRepository.AddVehicleToPerson(carBrand, personId);
        }

        public async Task DeleteVehicle(string carBrand)
        {
            await _vehicleRepository.DeleteVehicle(carBrand);
        }

        public async Task<GetVehicleModel> GetVehicle(string carbrand)
        {
           return await _vehicleRepository.GetVehicle(carbrand);
        }

        public async Task<IEnumerable<GetVehicleModel>> GetVehicles()
        {
           return await _vehicleRepository.GetVehicles();
        }
    }
}
