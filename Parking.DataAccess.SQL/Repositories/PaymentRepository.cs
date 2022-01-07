using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
using System.Threading.Tasks;

namespace Parking.DataAccess.SQL.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ParkingContext _context;

        public PaymentRepository(ParkingContext context)
        {
            _context = context;
        }

        public async Task CreatePayment(CreatePaymentModel paymentModel)
        {
            _context.Payments.Add(new Entities.Payment
            {
                Cost = paymentModel.Cost,
                PersonId = new Guid(paymentModel.PersonId)
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeletePayment(string paymentId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == new Guid(paymentId));
            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();
        }
    }
}
