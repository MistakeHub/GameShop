using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Repository.Record
{
    public class RecordRepositoryImpl : IRecordRepository
    {

        shopContext _context;

        public RecordRepositoryImpl(shopContext context)
        {
            _context = context;
        }
        public IEnumerable MostProfitableProduct()
        {
           
            return _context.Transactions.Include(d=>d.Publication).ThenInclude(d=>d.Game).AsEnumerable().GroupBy(d => d.Publication.Game.Titleofgame).Select(d => new { Game = d.Key, Total = d.Sum(p => p.Publication.Price) }).OrderByDescending(d=>d.Total);
        }

        public IEnumerable MostPurcheasableProduct()
        {
          
            return _context.Transactions.GroupBy(d => d.Publication.Game.Titleofgame).Select(d => new { Game = d.Key, Total = d.Count() }).OrderByDescending(d=>d.Total);
        }
    }
}
