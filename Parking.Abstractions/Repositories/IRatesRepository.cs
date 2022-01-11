using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IRatesRepository
    {
        public Task CreateRate(CreateRateModel rateModel);

        public Task DeleteRate(string rateId);

        public Task<IEnumerable<GetRatesModel>> GetRates();

        public Task<GetRatesModel> GetRate(string id);
    }
}
