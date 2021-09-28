using BackEnd.Models.SaveToFile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class LocalizationRepository:  IGenericRepository<Localization>
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
            Localization localization = _context.Localizations.SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
            localization.Titleoflocalization = value;
            _context.Localizations.Update(localization);
            _context.SaveChanges();
        }

        public Localization GetElement(int id)
        {
            return _context.Localizations.SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
        }

        public IEnumerable<Localization> GetElements(out int total)
        {
            total = _context.Localizations.Where(d => d.IsDeleted == false).Count();
            return _context.Localizations.Where(d => d.IsDeleted == false).ToList();
        }

        public IEnumerable<Localization> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Localizations.Where(d => d.IsDeleted == false).Count();

            return _context.Localizations.Where(d => d.IsDeleted == false).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
               return _context.Localizations.Where(d => d.IsDeleted == false).Select(d => d.Titleoflocalization).ToList();
        }

        public void LoadfromJson()
        {
            IEnumerable<Localization> localizations = FileSave<Localization>.LoadFromJson("Localizations.json");

            _context.Localizations.AddRange(localizations);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Localization> remove = _context.Localizations.Where(d => d.Id != 0);
            foreach (var item in remove)
            {
                item.IsDeleted = true;
                _context.Localizations.Update(item);
            }
            _context.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            Localization localization = _context.Localizations.SingleOrDefault(p => p.Id == id);
            localization.IsDeleted = true;
            _context.Localizations.Update(localization);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await FileSave<Localization>.SaveToJson("Localizations.json", _context.Localizations);
        }

    }
}
