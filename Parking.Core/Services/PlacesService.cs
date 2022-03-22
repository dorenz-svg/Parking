using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly IPlacesRepository _repository;
        private readonly IRatesRepository _ratesRepository;
        private readonly IPaymentService _paymentService;

        public PlacesService(IPlacesRepository repository, IRatesRepository ratesRepository, IPaymentService paymentService)
        {
            _repository = repository;
            _ratesRepository = ratesRepository;
            _paymentService = paymentService;
        }

        public async Task AddDates(long placeId, DateTime dateArrival, DateTime? dateLeaving)
        {
            await _repository.AddDates(placeId, dateArrival, dateLeaving);
            var rate = await _ratesRepository.GetRate(placeId);
            if (dateLeaving is not null)
            {
                TimeSpan? time = dateLeaving - dateArrival;
                int countHours = time.Value.Hours;
                var cost = (countHours * rate.CostPerHour) - (countHours * rate.CostPerHour * (decimal)(rate.Discount / 100));
                var personId = await _repository.GetPersonId(placeId);
                if (personId == default)
                    return;
                await _paymentService.CreatePayment(new CreatePaymentModel
                {
                    Cost = cost,
                    PersonId = personId ?? 0
                });
            }
        }

        public async Task CreatePlace(CreatePlaceModel createPlace)
        {
            await _repository.CreatePlace(createPlace);
        }

        public async Task DeletePlace(long placeId)
        {
            await _repository.DeletePlace(placeId);
        }

        public async Task<IEnumerable<GetPlacesModel>> GetPlaces()
        {
            return await _repository.GetPlaces();
        }

        public async Task<GetPlacesModel> GetPlace(long id)
        {
            return await _repository.GetPlace(id);
        }
    }
}
