using Parking.Abstractions.Models;
using System;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IPlacesRepository
    {
        public Task CreatePlace(CreatePlaceModel createPlace);

        public Task DeletePlace(string placeId);
    }
}
