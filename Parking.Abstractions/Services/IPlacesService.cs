using Parking.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Services
{
    public interface IPlacesService
    {
        public Task CreatePlace(CreatePlaceModel createPlace);

        public Task DeletePlace(string placeId);

        public Task AddDates(string placeId, DateTime dateArrival, DateTime? dateLeaving);

        public Task<IEnumerable<GetPlacesModel>> GetPlaces();
        public Task<GetPlacesModel> GetPlace(string id);
    }
}
