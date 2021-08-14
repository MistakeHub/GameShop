using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class SeriesRepository:IGenericRepository<Serie>
    {

        private readonly shopContext _context;
        public SeriesRepository(shopContext context)
        {
            _context = context;
        }
        public void AddElement(string value)
        {
            Serie serie = new Serie();
            serie.Titleofseries = value;
            _context.Series.Add(serie);
        }

        public void EditElement(int id, string value)
        {
            Serie serie = _context.Series.SingleOrDefault(p => p.Id == id);
            serie.Titleofseries = value;
            _context.Series.Update(serie);
            _context.SaveChanges();
        }

        public Serie GetElement(int id)
        {
            return _context.Series.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Serie> GetElements(out int total)
        {
            total = _context.Series.Count();
            return _context.Series.ToList();
        }

        public IEnumerable<Serie> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Series.Count();

            return _context.Series.Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Series.Select(d => d.Titleofseries);
        }

        public void RemoveElement(int id)
        {
            Serie serie = _context.Series.SingleOrDefault(p => p.Id == id);
            _context.Series.Remove(serie);
            _context.SaveChanges();
        }
    }
}
