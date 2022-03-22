using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IPersonRepository
    {
        public Task CreatePerson(CreatePersonModel personModel);

        public Task DeletePerson(long personId);

        public Task<string> GerPersonId(long personId);

        public Task<GetPersonModel> GetPerson(long personId);

        public Task<IEnumerable<GetPersonModel>> GetPersons();

        public Task<IEnumerable<string>> GetPlaces(long personId);
    }
}
