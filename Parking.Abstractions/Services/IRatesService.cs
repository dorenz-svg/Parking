using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Services
{
    public interface IRatesService
    {
        public Task CreateRate(CreateRateModel rateModel);

        public Task DeleteRate(long rateId);

        public Task<IEnumerable<GetRatesModel>> GetRates();
    }
}
