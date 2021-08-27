using BackEnd.Models.SaveToFile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class GenreRepository: FileSave<Genre>, IGenericRepository<Genre>
    {

        private readonly shopContext _context;
        public GenreRepository(shopContext context)
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
            Genre genre = _context.Genres.SingleOrDefault(p => p.Id == id);
            genre.Titleofgenre = value;
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }

        public Genre GetElement(int id)
        {
            return _context.Genres.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Genre> GetElements(out int total)
        {
            total = _context.Genres.Count();
            return _context.Genres.ToList();
        }

        public IEnumerable<Genre> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Genres.Count();

            return _context.Genres.Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Genres.Select(d=>d.Titleofgenre);
        }

        public void LoadfromJson()
        {
            IEnumerable<Genre> genres = LoadFromJson("Genres.json");
        }

        public void RemoveElement(int id)
        {
            Genre genre = _context.Genres.SingleOrDefault(p => p.Id == id);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await SaveToJson("Genres.json", _context.Genres);
        }
    }
}
