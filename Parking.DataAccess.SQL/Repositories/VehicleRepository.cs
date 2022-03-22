using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.DataAccess.SQL.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ParkingContext _context;

        public VehicleRepository(ParkingContext context)
        {
            _context = context;
        }

        public async Task AddVehicleToPerson(string carBrand, long personId)
        {
            _context.Vehicles.Add(new Entities.Vehicle
            {
                CarNumber = carBrand,
                PersonId = personId
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicle(string carBrand)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.CarNumber == carBrand);
            _context.Vehicles.Remove(vehicle);

            await _context.SaveChangesAsync();
        }

        public async Task<GetVehicleModel> GetVehicle(string carNumber)
        {
            return await _context.Vehicles.AsNoTracking()
                .Where(x => x.CarNumber == carNumber)
                .Select(x => new GetVehicleModel { CarNumber = x.CarNumber, PersonId = x.PersonId })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GetVehicleModel>> GetVehicles()
        {
            return await _context.Vehicles
               .Select(x => new GetVehicleModel
               {
                   Id = x.Id,
                   CarNumber = x.CarNumber,
                   PersonId= x.PersonId
               })
               .Take(20)
               .ToListAsync();
        }
    }
}
