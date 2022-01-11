using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
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
        public async Task AddVehicleToPerson(string carBrand, string personId)
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
    }
}
