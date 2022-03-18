using Parking.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IPlacesRepository
    {
        public Task CreatePlace(CreatePlaceModel createPlace);

        public Task DeletePlace(long placeId);

        public Task AddDates(long placeId, DateTime dateArrival, DateTime? dateLeaving);

        public Task<IEnumerable<GetPlacesModel>> GetPlaces();

        public Task<GetPlacesModel> GetPlace(long id);

        public Task<long?> GetPersonId(long placeId);
    }
}
