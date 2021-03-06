using BackEnd.Models.SaveToFile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class StatuseRepository:IGenericRepository<Statuse>
    {


        private readonly shopContext _context;
        public StatuseRepository(shopContext context)
        {
            _context = context;
        }
        public void AddElement(string value)
        {
            Statuse statuse = new Statuse();
            statuse.Titleofstatuse = value;
            _context.Statuses.Add(statuse);
            _context.SaveChanges();
        }

        public void EditElement(int id, string value)
        {
            Statuse statuse = _context.Statuses.SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
            statuse.Titleofstatuse = value;
            _context.Statuses.Update(statuse);
            _context.SaveChanges();
        }

        public Statuse GetElement(int id)
        {
            return _context.Statuses.SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
        }

        public IEnumerable<Statuse> GetElements(out int total)
        {
            total = _context.Statuses.Where(d => d.IsDeleted == false).Count();
            return _context.Statuses.Where(d => d.IsDeleted == false).ToList();
        }

        public IEnumerable<Statuse> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Statuses.Count();

            return _context.Statuses.Where(d => d.IsDeleted == false).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Statuses.Where(d => d.IsDeleted == false).Select(d => d.Titleofstatuse).ToList();
        }

        public void LoadfromJson()
        {
            IEnumerable<Statuse> statuses = FileSave<Statuse>.LoadFromJson("Statuses.json");

            _context.Statuses.AddRange(statuses);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Statuse> remove = _context.Statuses.Where(d => d.Id != 0 && d.Titleofstatuse !="Администратор");
            foreach (var item in remove)
            {
                item.IsDeleted = true;
                _context.Statuses.Update(item);
            }
            _context.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            Statuse statuse = _context.Statuses.SingleOrDefault(p => p.Id == id);
           
           statuse.IsDeleted = true;
            _context.Statuses.Update(statuse);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await FileSave<Statuse>.SaveToJson("Statuses.json", _context.Statuses);
        }
    }
}
