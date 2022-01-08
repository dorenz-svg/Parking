using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IPersonRepository
    {
        public Task CreatePerson(CreatePersonModel personModel);

        public Task DeletePerson(string phone);

        public Task<string> GerPersonId(string phone);

        public Task<GetPersonModel> GetPerson(string phone);

        public Task AddVehicleToPerson(string carBrand, string personId);

        public Task<IEnumerable<string>> GetPlaces(string personId);
    }
}
