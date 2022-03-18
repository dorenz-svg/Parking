using Microsoft.EntityFrameworkCore;
using Parking.Abstractions.Models;
using Parking.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.DataAccess.SQL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ParkingContext _context;

        public PersonRepository(ParkingContext context)
        {
            _context = context;
        }

        public async Task CreatePerson(CreatePersonModel personModel)
        {
            _context.People.Add(new Entities.Person
            {
                Name = personModel.Name,
                SurName = personModel.SurName,
                Phone = personModel.Phone,
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeletePerson(string phone)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Phone == phone);
            _context.People.Remove(person);

            await _context.SaveChangesAsync();
        }

        public async Task<string> GerPersonId(string phone)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Phone == phone);
            return person?.Id.ToString();
        }

        public async Task<GetPersonModel> GetPerson(string phone)
        {
            var person = await _context.People.FirstOrDefaultAsync(x => x.Phone == phone);

            if (person is null)
                return null;

            return new GetPersonModel 
            { 
                Id = person.Id,
                SurName = person.SurName,
                Name = person.Name,
                Phone = person.Phone 
            };
        }

        public async Task<IEnumerable<string>> GetPlaces(long personId)
        {
            return await _context.Places.Where(x => x.PersonId == personId).Select(x => x.Id.ToString()).ToListAsync();
        }
    }
}
