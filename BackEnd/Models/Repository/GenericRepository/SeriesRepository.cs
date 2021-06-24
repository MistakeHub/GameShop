using System;
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

        public IEnumerable<Serie> GetElements()
        {
            return _context.Series.ToList();
        }

        public void RemoveElement(int id)
        {
            Serie serie = _context.Series.SingleOrDefault(p => p.Id == id);
            _context.Series.Remove(serie);
            _context.SaveChanges();
        }
    }
}
