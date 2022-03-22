using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                PersonId = paymentModel.PersonId
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeletePayment(long paymentId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(x => x.Id == paymentId);
            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetPaymentModel>> GetPayments(long userId)
        {
           var payments=await _context.Payments.Include(x => x.Person)
                .Where(x => x.Person.Id == userId)
                .Select(x => new GetPaymentModel
                {
                    Surname=x.Person.SurName,
                    Name=x.Person.Name,
                    Cost=x.Cost,
                    Id=x.Id
                }).ToListAsync();

            return payments;
        }
    }
}
