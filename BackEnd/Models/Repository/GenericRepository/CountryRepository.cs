﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class CountryRepository : IGenericRepository<Country>
    {

        private readonly shopContext _context;
        public CountryRepository(shopContext context)
        {
            _context = context;
        }
        public void AddElement(string value)
        {
            Country country = new Country();
            country.Titleofcountry =value;
            _context.Countries.Add(country);
        }

        public void EditElement(int id, string value)
        {
            Country country = _context.Countries.SingleOrDefault(p => p.Id == id);
            country.Titleofcountry = value;
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public Country GetElement(int id)
        {
           return _context.Countries.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Country> GetElements()
        {
           return _context.Countries.ToList();
        }

        public void RemoveElement(int id)
        {
            Country country = _context.Countries.SingleOrDefault(p => p.Id == id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }
    }
}
