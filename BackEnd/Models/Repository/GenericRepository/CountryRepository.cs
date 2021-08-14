using System;
using System.Collections;
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

        public IEnumerable<Country> GetElements(out int total)
        {
            total = _context.Countries.Count();
           return _context.Countries.ToList();
        }

        public IEnumerable<Country> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Countries.Count();

            return _context.Countries.Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Countries.Select(d=>d.Titleofcountry);
        }

        public void RemoveElement(int id)
        {
            Country country = _context.Countries.SingleOrDefault(p => p.Id == id);
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }
    }
}
