using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models.Repository.PublicationRepository
{
    public class PublicationRepository : IPublicationRepository
    {


        private readonly shopContext _context;

        public PublicationRepository(shopContext context)
        {
            _context = context;
        }
        public void AddComment(int id,string text)
        {
            Comment comment = new Comment();
            comment.Text = text;
            comment.Counoflikes = 0;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            Publication publication=_context.Publications.SingleOrDefault(p => p.Id == comment.Publication.Id);
            publication.Comments.Add(comment);
            _context.Publications.Update(publication);
            _context.SaveChanges();
        }

        public void AddPublication(string titleofgame, string description, DateTime datarealese, int idplatforms,int idlocalizations, int idgenres, int idmanufactures, int idregionRestrict, int idseries, double price)
        {
            Game game = _context.Games.SingleOrDefault(p=>p.Titleofgame==titleofgame);
            
           Platform  platforms= _context.Platforms.SingleOrDefault(p => idplatforms==p.Id);
           Localization localizations = _context.Localizations.SingleOrDefault(p => idlocalizations == p.Id);
            Genre genres = _context.Genres.SingleOrDefault(p => idgenres == p.Id);
            Manufacture manufactures = _context.Manufactures.SingleOrDefault(p => idmanufactures == p.Id);
            Country country = _context.Countries.SingleOrDefault(p => p.Id == idregionRestrict);
            Serie series = _context.Series.SingleOrDefault(p => p.Id == idseries);
            game.Titleofgame = titleofgame;
            game.Description = description;
            game.DateRelese = datarealese;
            game.Manufactures.Add(manufactures);
            game.Platforms.Add(platforms);
            game.Localizations.Add(localizations);
            game.Genres.Add(genres);
            game.Series=series;
            _context.Entry(game).State = EntityState.Modified;
            _context.Games.Add(game);
            _context.SaveChanges();
            game.Products.Add(new Product { Game = game, Genre = genres, Localization = localizations, Manufacture=manufactures, Platform=platforms, RegionRestrict=country});

            _context.Publications.Add(new Publication { Game = game, Price = price, Comments = new List<Comment>() });
            _context.SaveChanges();

        }

       

        public void EditPublication(int id, string titleofgame, string description, DateTime datarealese, int[] platforms, int[] manufactures, int[] localizations, int[] genres, int series, double price)
        {
            Game game = _context.Games.SingleOrDefault(p => p.Id == id);
            Publication publication = game.Publication;
            game.Titleofgame = titleofgame;
            game.Description = description;
            game.DateRelese = datarealese;
            game.Manufactures.Select(p=>manufactures.Contains(p.Id));
            game.Platforms.Select(p => platforms.Contains(p.Id));
            game.Localizations.Select(p => localizations.Contains(p.Id));
            game.Genres.Select(p => genres.Contains(p.Id));
            game.Series = _context.Series.SingleOrDefault(p=>p.Id==series);
            publication.Price = price;
            publication.Game = game;
            _context.Games.Update(game);
            _context.Publications.Update(publication);
            _context.SaveChanges();
        }

        public Publication GetPublication(int id)
        {
            return _context.Publications.SingleOrDefault(p=>p.Id==id);
        }

        public IEnumerable<Publication> GetPublications(int page, int size=5)
        {
            return _context.Publications.Include(p=>p.Game).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(p => p.Game.RegionRestricts).Include(p=>p.Game.Genres).Include(p => p.Game.Series).Skip((page - 1) * size).Take(size).ToList();
        }

        public void RemoveComment(int id)
        {
            var remove = _context.Comments.SingleOrDefault(p => p.Id == id);
            _context.Remove(remove);
            _context.SaveChanges();
        }

        public void RemovePublication(int id)
        {
            var remove = _context.Publications.SingleOrDefault(p => p.Id == id);
            _context.Remove(remove);
            _context.SaveChanges();
        }
    }
}
