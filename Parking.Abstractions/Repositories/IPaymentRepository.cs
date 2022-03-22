using Parking.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Abstractions.Repositories
{
    public interface IPaymentRepository
    {
        public Task CreatePayment(CreatePaymentModel paymentModel);

        public Task DeletePayment(long paymentId);

        public Task<IEnumerable<GetPaymentModel>> GetPayments(long userId);
    }
}
