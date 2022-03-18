using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using Parking.Abstractions.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreatePayment(CreatePaymentModel paymentModel)
        {
            await _repository.CreatePayment(paymentModel);
        }

        public async Task DeletePayment(long paymentId)
        {
            await _repository.DeletePayment(paymentId);
        }

        public async Task<IEnumerable<GetPaymentModel>> GetPayments(string phonePerson)
        {
           return await _repository.GetPayments(phonePerson);
        }
    }
}
