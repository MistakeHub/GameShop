using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models.SaveToFile;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class ManufactureRepository: IGenericRepository<Manufacture>
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
            _context.SaveChanges();
        }

        public void EditElement(int id, string value)
        {
            Manufacture manufacture = _context.Manufactures.SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
            manufacture.Titleofmanufactures = value;
            _context.Manufactures.Update(manufacture);
            _context.SaveChanges();
        }

        public Manufacture GetElement(int id)
        {
            return _context.Manufactures.Include(d => d.Games).SingleOrDefault(p => p.Id == id && p.IsDeleted == false) ;
        }

        public IEnumerable<Manufacture> GetElements(out int total)
        {
            total = _context.Manufactures.Where(d => d.IsDeleted == false).Count();
            return _context.Manufactures.Where(d => d.IsDeleted == false).ToList();
        }

        public IEnumerable<Manufacture> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Manufactures.Where(d => d.IsDeleted == false).Count();

            return _context.Manufactures.Where(d => d.IsDeleted == false).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Manufactures.Where(d => d.IsDeleted == false).Select(d => d.Titleofmanufactures).ToList(); ;
        }

        public void LoadfromJson()
        {
            IEnumerable<Manufacture> manufactures = FileSave<Manufacture>.LoadFromJson("Manufactures.json");

            _context.Manufactures.AddRange(manufactures);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Manufacture> remove = _context.Manufactures.Where(d => d.Id != 0);
            foreach (var item in remove)
            {
                item.IsDeleted = true;
                _context.Manufactures.Update(item);
            }
            _context.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            Manufacture manufacture = _context.Manufactures.AsNoTrackingWithIdentityResolution().SingleOrDefault(p => p.Id == id);
            manufacture.IsDeleted = true;
            _context.Entry(manufacture).State = EntityState.Modified;
     
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await FileSave<Manufacture>.SaveToJson("Manufactures.json", _context.Manufactures);
        }


    }
}
