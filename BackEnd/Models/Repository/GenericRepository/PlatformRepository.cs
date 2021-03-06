using BackEnd.Models.SaveToFile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class PlatformRepository:  IGenericRepository<Platform>
    {

        private readonly shopContext _context;
        public PlatformRepository(shopContext context)
        {
            _context = context;
        }
        public void AddElement(string value)
        {
            Platform platform = new Platform();
            platform.Titleofplatform = value;
            _context.Platforms.Add(platform);
            _context.SaveChanges();
        }

        public void EditElement(int id, string value)
        {
            Platform platform = _context.Platforms.SingleOrDefault(p => p.Id == id&& p.IsDeleted==false);
            platform.Titleofplatform = value;
            _context.Platforms.Update(platform);
            _context.SaveChanges();
        }

        public Platform GetElement(int id)
        {
            return _context.Platforms.Include(d=>d.Games).SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
        }

        public IEnumerable<Platform> GetElements(out int total)
        {
            total = _context.Platforms.Where(d => d.IsDeleted == false).Count();
            return _context.Platforms.Where(d => d.IsDeleted == false).ToList();
        }

        public IEnumerable<Platform> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Platforms.Where(d => d.IsDeleted == false).Count();

            return _context.Platforms.Where(d => d.IsDeleted == false).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Platforms.Where(d => d.IsDeleted == false).Select(d => d.Titleofplatform).ToList();
        }

        public void LoadfromJson()
        {
            IEnumerable<Platform> platforms = FileSave<Platform>.LoadFromJson("Platforms.json");

            _context.Platforms.AddRange(platforms);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Platform> remove = _context.Platforms.Where(d => d.Id != 0);
            foreach (var item in remove)
            {
                item.IsDeleted = true;
                _context.Platforms.Update(item);
            }
            _context.SaveChanges();
        }
        public void RemoveElement(int id)
        {
            Platform platform = _context.Platforms.SingleOrDefault(p => p.Id == id);
            platform.IsDeleted = true;
            _context.Platforms.Update(platform);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await FileSave<Platform>.SaveToJson("Platforms.json", _context.Platforms);
        }


    }
}
