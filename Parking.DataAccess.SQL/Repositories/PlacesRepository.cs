using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
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

        public async  Task AddDates(string placeId, DateTime dateArrival, DateTime? dateLeaving)
        {
            _context.Dates.Add(new Entities.Dates 
            { 
                PlaceId = new Guid(placeId), 
                DateArrival = dateArrival, 
                DateLeaving = dateLeaving 
            });

            await _context.SaveChangesAsync();
        }

        public async Task CreatePlace(CreatePlaceModel createPlace)
        {
            _context.Places.Add(new Entities.Place
            {
                PersonId = new Guid(createPlace.PersonId),
                IdRates = new Guid(createPlace.IdRates)
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlace(string placeId)
        {
            var place = await _context.Places.FirstOrDefaultAsync(x => x.Id == new Guid(placeId));
            _context.Places.Remove(place);

            await _context.SaveChangesAsync();
        }
    }
}
