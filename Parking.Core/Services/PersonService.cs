using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreatePerson(CreatePersonModel personModel)
        {
            await _personRepository.CreatePerson(personModel);
        }

        public async Task DeletePerson(long personId)
        {
            await _personRepository.DeletePerson(personId);
        }

        public async Task<GetPersonModel> GetPerson(long personId)
        {
            return await _personRepository.GetPerson(personId);
        }

        public async Task<IEnumerable<GetPersonModel>> GetPersons()
        {
            return await _personRepository.GetPersons();
        }
    }
}
