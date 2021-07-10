using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.GenericRepository
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetElements();
        T GetElement(int id);
        void AddElement(string value);
        void EditElement(int id, string value);
        void RemoveElement(int id);
        IEnumerable GetTitles();
    }
}
