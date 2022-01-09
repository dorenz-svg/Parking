using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Services
{
    public class RatesService : IRatesService
    {
        private readonly IRatesRepository _repository;

        public RatesService(IRatesRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateRate(CreateRateModel rateModel)
        {
            await _repository.CreateRate(rateModel);
        }

        public async Task DeleteRate(string rateId)
        {
            await _repository.DeleteRate(rateId);
        }

        public async Task<IEnumerable<GetRatesModel>> GetRates()
        {
            return await _repository.GetRates();
        }
    }
}
