using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class PlatformRepository:IGenericRepository<Platform>
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
        }

        public void EditElement(int id, string value)
        {
            Platform platform = _context.Platforms.SingleOrDefault(p => p.Id == id);
            platform.Titleofplatform = value;
            _context.Platforms.Update(platform);
            _context.SaveChanges();
        }

        public Platform GetElement(int id)
        {
            return _context.Platforms.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Platform> GetElements()
        {
            return _context.Platforms.ToList();
        }

        public void RemoveElement(int id)
        {
            Platform platform = _context.Platforms.SingleOrDefault(p => p.Id == id);
            _context.Platforms.Remove(platform);
            _context.SaveChanges();
        }

    }
}
