using BackEnd.Models.SaveToFile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class CountryRepository :  IGenericRepository<Country>
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
            _context.SaveChanges();
        }

        public void EditElement(int id, string value)
        {
            Country country = _context.Countries.SingleOrDefault(p => p.Id == id && p.IsDeleted);
            country.Titleofcountry = value;
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public Country GetElement(int id)
        {
           return _context.Countries.Where(d => d.IsDeleted == false).SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
        }

        public IEnumerable<Country> GetElements(out int total)
        {
            total = _context.Countries.Where(d => d.IsDeleted == false).Count();
           return _context.Countries.Where(d => d.IsDeleted == false).ToList();
        }

        public IEnumerable<Country> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Countries.Where(d => d.IsDeleted == false).Count();

            return _context.Countries.Where(d => d.IsDeleted == false).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Countries.Where(d => d.IsDeleted == false).Select(d=>d.Titleofcountry);
        }

        public void LoadfromJson()
        {
            IEnumerable<Country> countries = FileSave < Country>. LoadFromJson("Countries.json");

            
            _context.Countries.AddRange(countries);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Country> remove = _context.Countries.Where(d => d.Id != 0);
            foreach (var item in remove)
            {
                item.IsDeleted = true;
                _context.Countries.Update(item);
            }
            _context.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            Country country = _context.Countries.SingleOrDefault(p => p.Id == id);
            country.IsDeleted = true;
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await FileSave<Country>.SaveToJson("Country.json", _context.Countries);
        }
    }
}
