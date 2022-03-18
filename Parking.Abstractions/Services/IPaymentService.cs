using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Services
{
    public interface IPaymentService
    {
        public Task<IEnumerable<GetPaymentModel>> GetPayments(string phonePerson);

        public Task CreatePayment(CreatePaymentModel paymentModel);

        public Task DeletePayment(long paymentId);
    }
}
