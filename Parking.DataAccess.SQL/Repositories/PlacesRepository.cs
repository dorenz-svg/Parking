using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.DataAccess.SQL.Repositories
{
    public class PlacesRepository : IPlacesRepository
    {
        private readonly ParkingContext _context;

        public PlacesRepository(ParkingContext context)
        {
            _context = context;
        }

        public async  Task AddDates(long placeId, DateTime dateArrival, DateTime? dateLeaving)
        {
            _context.Dates.Add(new Entities.Dates 
            { 
                PlaceId = placeId, 
                DateArrival = dateArrival, 
                DateLeaving = dateLeaving 
            });

            await _context.SaveChangesAsync();
        }

        public async Task CreatePlace(CreatePlaceModel createPlace)
        {
            _context.Places.Add(new Entities.Place
            {
                PersonId = createPlace.PersonId,
                IdRates = createPlace.IdRates
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlace(long placeId)
        {
            var place = await _context.Places.FirstOrDefaultAsync(x => x.Id == placeId);

            if (place is null)
                return;

            _context.Places.Remove(place);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetPlacesModel>> GetPlaces()
        {
            return await _context.Places
                .Select(x=>new GetPlacesModel 
                {
                    Id = x.Id,
                    Cost = x.Rates.CostPerHour.ToString(),
                    PersonName = x.Person.Name.ToString()
                })
                .Take(20)
                .ToListAsync();
        }

        public async Task<GetPlacesModel> GetPlace(long id)
        {
            return await _context.Places
                .Include(x=>x.Person)
                .Include(x=>x.Rates)
                .Where(x=>x.Id== id)
                .Select(x => new GetPlacesModel
                {
                    Id = x.Id,
                    Cost = x.Rates.CostPerHour.ToString(),
                    PersonName = x.Person.Name.ToString()
                })
                .FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<long?> GetPersonId(long placeId)
        {
            var place= await _context.Places.FirstOrDefaultAsync(x => x.Id == placeId);
            return place.PersonId;
        }
    }
}
