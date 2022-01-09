﻿using Microsoft.EntityFrameworkCore;
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

        public async Task AddVehicleToPerson(string carNumber, string personId)
        {
            _context.Vehicles.Add(new Entities.Vehicle { CarNumber = carNumber, PersonId = new Guid(personId) });

            await _context.SaveChangesAsync();
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
            return new GetPersonModel 
            { 
                Id = person.Id.ToString(),
                SurName = person.SurName,
                Name = person.Name,
                Phone = person.Phone 
            };
        }

        public async Task<IEnumerable<string>> GetPlaces(string personId)
        {
            return await _context.Places.Where(x => x.PersonId == new Guid(personId)).Select(x => x.Id.ToString()).ToListAsync();
        }
    }
}