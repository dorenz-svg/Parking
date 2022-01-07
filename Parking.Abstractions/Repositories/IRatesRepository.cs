using Parking.Abstractions.Models;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IRatesRepository
    {
        public Task CreateRate(CreateRateModel rateModel);

        public Task DeleteRate(string rateId);
    }
}
