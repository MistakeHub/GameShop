using BackEnd.Models.SaveToFile;
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
            _context.SaveChanges();
        }

        public void EditElement(int id, string value)
        {
            Serie serie = _context.Series.SingleOrDefault(p => p.Id == id&&p.IsDeleted==false);
            serie.Titleofseries = value;
            _context.Series.Update(serie);
            _context.SaveChanges();
        }

        public Serie GetElement(int id)
        {
            return _context.Series.SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
        }

        public IEnumerable<Serie> GetElements(out int total)
        {
            total = _context.Series.Where(d => d.IsDeleted == false).Count();
            return _context.Series.Where(d => d.IsDeleted == false).ToList();
        }

        public IEnumerable<Serie> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Series.Where(d => d.IsDeleted == false).Count();

            return _context.Series.Where(d => d.IsDeleted == false).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Series.Where(d => d.IsDeleted == false).Select(d => d.Titleofseries);
        }

        public void LoadfromJson()
        {
            IEnumerable<Serie> series = FileSave<Serie>.LoadFromJson("Series.json");

            _context.Series.AddRange(series);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Serie> remove = _context.Series.Where(d => d.Id != 0);
            foreach (var item in remove)
            {
                item.IsDeleted = true;
                _context.Series.Update(item);
            }
            _context.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            Serie serie = _context.Series.SingleOrDefault(p => p.Id == id);
           serie.IsDeleted = true;
            _context.Series.Update(serie);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await FileSave<Serie>.SaveToJson("Series.json", _context.Series);
        }
    }
}
