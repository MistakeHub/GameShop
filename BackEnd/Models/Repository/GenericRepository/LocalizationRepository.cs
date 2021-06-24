using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class LocalizationRepository:IGenericRepository<Localization>
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

        public IEnumerable<Localization> GetElements()
        {
            return _context.Localizations.ToList();
        }

        public void RemoveElement(int id)
        {
            Localization localization = _context.Localizations.SingleOrDefault(p => p.Id == id);
            _context.Localizations.Remove(localization);
            _context.SaveChanges();
        }

    }
}
