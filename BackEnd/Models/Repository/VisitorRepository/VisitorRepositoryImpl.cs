using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.VisitorRepository
{
    public class VisitorRepositoryImpl : IVisitorRepository
    {

        private shopContext _context;


        public VisitorRepositoryImpl()
        {


        }
        public VisitorRepositoryImpl(shopContext context)
        {

            _context = context;
        }
        public void AddNewVisitor()
        {
            
            DateTime StartPeriod = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01);
            DateTime EndPeriod = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            Visitor visitor = _context.Visitors.FirstOrDefault(d => d.StartPeriod == StartPeriod);
            if (visitor==null)
            {
                _context.Visitors.Add(new Visitor() { Count = 1, StartPeriod = StartPeriod, EndPeriod = EndPeriod });
                _context.SaveChanges();

            }
            else
            {

                visitor.Count++;
                _context.Visitors.Update(visitor);
                _context.SaveChanges();
            }
           
        }

        public IEnumerable<Visitor> GetVisitor()
        {
          return _context.Visitors.ToList();
        }
    }
}
