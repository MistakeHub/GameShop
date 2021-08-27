using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.VisitorRepository
{
    public interface IVisitorRepository
    {
        IEnumerable<Visitor> GetVisitor();
        void AddNewVisitor();
    }
}
