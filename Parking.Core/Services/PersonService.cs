using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
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

        public async Task AddVehicleToPerson(string carBrand, string personId)
        {
            await _personRepository.AddVehicleToPerson(carBrand, personId);
        }

        public async Task CreatePerson(CreatePersonModel personModel)
        {
            await _personRepository.CreatePerson(personModel);
        }

        public async Task DeletePerson(string phone)
        {
            await _personRepository.DeletePerson(phone);
        }

        public async Task<GetPersonModel> GetPerson(string phone)
        {
            return await _personRepository.GetPerson(phone);
        }
    }
}
