using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
using System.Threading.Tasks;

namespace Parking.DataAccess.SQL.Repositories
{
    public class RatesRepository : IRatesRepository
    {
        private readonly ParkingContext _context;

        public RatesRepository(ParkingContext context)
        {
            _context = context;
        }

        public async Task CreateRate(CreateRateModel rateModel)
        {
            _context.Rates.Add(new Entities.Rates 
            {
                Discount=rateModel.Discount,
                CostPerHour=rateModel.CostPerHour
            });

           await _context.SaveChangesAsync();
        }

        public async Task DeleteRate(string rateId)
        {
            var rate = await _context.Rates.FirstOrDefaultAsync(x => x.Id == new Guid(rateId));

            _context.Rates.Remove(rate);

            await _context.SaveChangesAsync();
        }
    }
}
