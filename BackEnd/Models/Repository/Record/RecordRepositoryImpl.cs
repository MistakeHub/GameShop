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
        public IEnumerable MostProfitableProduct(DateTime? from, DateTime? to, string[] genres, string[] manufactures, string[] platforms, string[] localizations)
        {
            if (from == null)
                from = _context.Transactions.AsNoTracking().OrderBy(d => d.DateOfOperation).FirstOrDefault().DateOfOperation;

            if (to == null)
                to = _context.Transactions.AsNoTracking().OrderByDescending(d => d.DateOfOperation).FirstOrDefault().DateOfOperation;


            return _context.Transactions.Include(d=>d.Publication).ThenInclude(d=>d.Game).Include(p => p.Publication.Game.Localizations).Include(p => p.Publication.Game.Manufactures).Include(p => p.Publication.Game.Platforms).Include(d => d.Publication.Images).
                Include(p => p.Publication.Game.Genres).Include(p => p.Publication.Game.Series).AsEnumerable().Where(d=> d.Publication.Game.Localizations.Any(p => localizations.Contains(p.Titleoflocalization)) && d.Publication.Game.Genres.Any(p => genres.Contains(p.Titleofgenre)) && d.Publication.Game.Platforms.Any(p => platforms.Contains(p.Titleofplatform)) && d.Publication.Game.Manufactures.Any(p => manufactures.Contains(p.Titleofmanufactures)) && d.DateOfOperation >= from && d.DateOfOperation <= to).GroupBy(d => d.Publication.Game.Titleofgame).Select(d => new { Game = d.Key, Total = d.Sum(p => p.Publication.Price) }).OrderByDescending(d=>d.Total);
        }

        public IEnumerable MostPurcheasableProduct(DateTime? from, DateTime? to, string[] genres, string[] manufactures, string[] platforms, string[] localizations)
        {
            if (from == null)
                from = _context.Transactions.AsNoTracking().OrderBy(d=>d.DateOfOperation).FirstOrDefault().DateOfOperation;

            if (to == null)
                to = _context.Transactions.AsNoTracking().OrderByDescending(d => d.DateOfOperation).FirstOrDefault().DateOfOperation;

            return _context.Transactions.Where(d => d.Publication.Game.Localizations.Any(p => localizations.Contains(p.Titleoflocalization)) && d.Publication.Game.Genres.Any(p => genres.Contains(p.Titleofgenre)) && d.Publication.Game.Platforms.Any(p => platforms.Contains(p.Titleofplatform)) && d.Publication.Game.Manufactures.Any(p => manufactures.Contains(p.Titleofmanufactures)) && d.DateOfOperation >= from && d.DateOfOperation <= to).GroupBy(d => d.Publication.Game.Titleofgame).Select(d => new { Game = d.Key, Total = d.Count() }).OrderByDescending(d=>d.Total);
        }
    }
}
