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

        public IEnumerable MostProfitableRatingProduct( string[] genres, string[] manufactures, string[] platforms, string[] localizations)
        {


            return _context.Publications.AsNoTracking().Include(d => d.Game).Include(d => d.Game.Platforms).Include(d => d.Game.Localizations).Include(d => d.Game.Genres).Include(d => d.Game.Manufactures).Include(d => d.Game.Series).Where(d => d.Game.Localizations.Any(p => localizations.Contains(p.Titleoflocalization)) && d.Game.Genres.Any(p => genres.Contains(p.Titleofgenre)) && d.Game.Platforms.Any(p => platforms.Contains(p.Titleofplatform)) && d.Game.Manufactures.Any(p => manufactures.Contains(p.Titleofmanufactures))).GroupBy(d =>new { d.Game.Titleofgame, d.Rating }).Select(d => new { Game = d.Key.Titleofgame, Rating=d.Key.Rating }).OrderByDescending(d=>d.Rating).ToList();
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
