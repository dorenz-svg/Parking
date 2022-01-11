﻿using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Discount = rateModel.Discount,
                CostPerHour = rateModel.CostPerHour
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRate(string rateId)
        {
            var rate = await _context.Rates.FirstOrDefaultAsync(x => x.Id == new Guid(rateId));

            _context.Rates.Remove(rate);

            await _context.SaveChangesAsync();
        }

        public async Task<GetRatesModel> GetRate(string id)
        {
            return await _context.Rates
                .Where(x=>x.Id==new Guid(id))
                .Select(x => new GetRatesModel
                {
                    CostPerHour = x.CostPerHour,
                    Discount = x.Discount,
                    Id = x.Id.ToString()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GetRatesModel>> GetRates()
        {
            return await _context.Rates
                .Select(x => new GetRatesModel
                {
                    CostPerHour = x.CostPerHour,
                    Discount = x.Discount,
                    Id = x.Id.ToString()
                })
                .Take(20)
                .ToListAsync();
        }
    }
}
