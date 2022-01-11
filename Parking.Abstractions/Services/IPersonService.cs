using Parking.Abstractions.Models;
using System.Threading.Tasks;

namespace Parking.Abstractions.Services
{
    public interface IPersonService
    {
        public Task CreatePerson(CreatePersonModel personModel);

        public Task<GetPersonModel> GetPerson(string phone);

        public Task DeletePerson(string phone);

        
    }
}
