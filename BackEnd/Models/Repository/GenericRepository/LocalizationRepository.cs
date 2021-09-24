using BackEnd.Models.SaveToFile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class LocalizationRepository: FileSave<Localization>, IGenericRepository<Localization>
    {

        private readonly shopContext _context;
        public LocalizationRepository(shopContext context)
        {
            _context = context;
        }
        public void AddElement(string value)
        {
            Genre genre = new Genre();
            genre.Titleofgenre = value;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void EditElement(int id, string value)
        {
            Localization localization = _context.Localizations.SingleOrDefault(p => p.Id == id);
            localization.Titleoflocalization = value;
            _context.Localizations.Update(localization);
            _context.SaveChanges();
        }

        public Localization GetElement(int id)
        {
            return _context.Localizations.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Localization> GetElements(out int total)
        {
            total = _context.Localizations.Count();
            return _context.Localizations.ToList();
        }

        public IEnumerable<Localization> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Localizations.Count();

            return _context.Localizations.Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
               return _context.Localizations.Select(d => d.Titleoflocalization).ToList();
        }

        public void LoadfromJson()
        {
            IEnumerable<Localization> localizations = LoadFromJson("Localizations.json");

            _context.Localizations.AddRange(localizations);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Localization> remove = _context.Localizations.Where(d => d.Id != 0);
            _context.Localizations.RemoveRange(remove);
            _context.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            Localization localization = _context.Localizations.SingleOrDefault(p => p.Id == id);
            _context.Localizations.Remove(localization);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await SaveToJson("Localizations.json", _context.Localizations);
        }

    }
}
