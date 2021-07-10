using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class RoleRepository:IGenericRepository<Role>
    {

        private readonly shopContext _context;
        public RoleRepository(shopContext context)
        {
            _context = context;
        }
        public void AddElement(string value)
        {
            Role role = new Role();
            role.TitleofRole = value;
            _context.Roles.Add(role);
        }

        public void EditElement(int id, string value)
        {
            Role role = _context.Roles.SingleOrDefault(p => p.Id == id);
            role.TitleofRole = value;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public Role GetElement(int id)
        {
            return _context.Roles.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Role> GetElements()
        {
            return _context.Roles.ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Roles.Select(d => d.TitleofRole).ToList();
        }

        public void RemoveElement(int id)
        {
            Role role = _context.Roles.SingleOrDefault(p => p.Id == id);
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

    }
}
