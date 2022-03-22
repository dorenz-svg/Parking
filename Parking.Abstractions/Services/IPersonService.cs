using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Services
{
    public interface IPersonService
    {
        public Task CreatePerson(CreatePersonModel personModel);

        public Task<GetPersonModel> GetPerson(long personId);

        public Task DeletePerson(long personId);

        public Task<IEnumerable<GetPersonModel>> GetPersons();
    }
}
