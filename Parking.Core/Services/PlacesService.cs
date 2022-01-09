using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly IPlacesRepository _repository;

        public PlacesService(IPlacesRepository repository)
        {
            _repository = repository;
        }
        public async Task AddDates(string placeId, DateTime dateArrival, DateTime? dateLeaving)
        {
            await _repository.AddDates(placeId, dateArrival, dateLeaving);
        }

        public async Task CreatePlace(CreatePlaceModel createPlace)
        {
            await _repository.CreatePlace(createPlace);
        }

        public async Task DeletePlace(string placeId)
        {
            await _repository.DeletePlace(placeId);
        }

        public async Task<IEnumerable<GetPlacesModel>> GetPlaces()
        {
            return await _repository.GetPlaces();
        }
    }
}
