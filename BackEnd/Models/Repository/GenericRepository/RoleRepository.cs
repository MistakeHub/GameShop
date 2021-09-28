using BackEnd.Models.SaveToFile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public class RoleRepository:  IGenericRepository<Role>
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
            _context.SaveChanges();
        }

        public void EditElement(int id, string value)
        {
            Role role = _context.Roles.SingleOrDefault(p => p.Id == id && p.IsDeleted==false);
            role.TitleofRole = value;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public Role GetElement(int id)
        {
            return _context.Roles.SingleOrDefault(p => p.Id == id&&p.IsDeleted==false);
        }

        public IEnumerable<Role> GetElements(out int total)
        {
            total = _context.Roles.Where(d => d.IsDeleted == false).Count();
            return _context.Roles.Where(d => d.IsDeleted == false).ToList();
        }

        public IEnumerable<Role> GetElementsByPage(int page, out int totalitems, int size)
        {
            totalitems = _context.Roles.Where(d => d.IsDeleted == false).Count();

            return _context.Roles.Where(d => d.IsDeleted == false).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable GetTitles()
        {
            return _context.Roles.Select(d => d.TitleofRole).ToList();
        }

        public void LoadfromJson()
        {
            IEnumerable<Role> roles = FileSave<Role>.LoadFromJson("Roles.json");



            _context.Roles.AddRange(roles);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Role> remove = _context.Roles.Where(d => d.Id != 0);
            foreach (var item in remove)
            {
                item.IsDeleted = true;
                _context.Roles.Update(item);
            }
            _context.SaveChanges();
        }

        public void RemoveElement(int id)
        {
            Role role = _context.Roles.SingleOrDefault(p => p.Id == id);
            role.IsDeleted = true;
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public async void SaveToJson()
        {
            await FileSave < Role > .SaveToJson("Roles.json", _context.Roles);
        }

    }
}
