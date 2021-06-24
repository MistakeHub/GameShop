using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class ManufactureRepository:IGenericRepository<Manufacture>
    {


        private readonly shopContext _context;
        public ManufactureRepository(shopContext context)
        {
            _context = context;
        }
        public void AddElement(string value)
        {
            Manufacture manufacture = new Manufacture();
            manufacture.Titleofmanufactures = value;
            _context.Manufactures.Add(manufacture);
        }

        public void EditElement(int id, string value)
        {
            Manufacture manufacture = _context.Manufactures.SingleOrDefault(p => p.Id == id);
            manufacture.Titleofmanufactures = value;
            _context.Manufactures.Update(manufacture);
            _context.SaveChanges();
        }

        public Manufacture GetElement(int id)
        {
            return _context.Manufactures.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Manufacture> GetElements()
        {
            return _context.Manufactures.ToList();
        }

        public void RemoveElement(int id)
        {
            Manufacture manufacture = _context.Manufactures.SingleOrDefault(p => p.Id == id);
            _context.Manufactures.Remove(manufacture);
            _context.SaveChanges();
        }
    }
}
