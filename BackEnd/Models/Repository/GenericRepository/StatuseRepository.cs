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
        }

        public void EditElement(int id, string value)
        {
            Statuse statuse = _context.Statuses.SingleOrDefault(p => p.Id == id);
            statuse.Titleofstatuse = value;
            _context.Statuses.Update(statuse);
            _context.SaveChanges();
        }

        public Statuse GetElement(int id)
        {
            return _context.Statuses.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Statuse> GetElements()
        {
            return _context.Statuses.ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Statuses.Select(d => d.Titleofstatuse).ToList();
        }

        public void RemoveElement(int id)
        {
            Statuse statuse = _context.Statuses.SingleOrDefault(p => p.Id == id);
            _context.Statuses.Remove(statuse);
            _context.SaveChanges();
        }
    }
}
