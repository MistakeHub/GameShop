using System;
using System.Collections;
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
        public IEnumerable AddComment(string username, int idpublication, string text)
        {
            User user = _context.Users.FirstOrDefault(d => d.Login == username);
            Comment comment = new Comment();
            comment.Text = text;
            comment.Countoflikes = 0;
            user.Comments.Add(comment);
            _context.Users.Update(user);
            _context.SaveChanges();
            Publication publication=_context.Publications.Include(d=>d.Comments).SingleOrDefault(p => p.Id == idpublication);
            publication.Comments.Add(comment);
            _context.Publications.Update(publication);
            _context.SaveChanges();
            return publication.Comments.ToList();
        }

        public void AddPublication(List<string> filenames,string titleofgame, string description, DateTime datarealese, string[] platforms, string[] localizations, string[] genres, string[] manufactures, string[] regionRestrict, string series, double price)
        {
            Game game =new Game();

            if (game == null) { game = new Game() { }; _context.Games.Add(game); _context.SaveChanges(); };
          
           List<Platform>  Platforms= _context.Platforms.Where(p => platforms.Contains(p.Titleofplatform)).ToList();
            List<Localization> Localizations = _context.Localizations.Where(p => localizations.Contains(p.Titleoflocalization)).ToList();
            List<Genre> Genres = _context.Genres.Where(p => genres.Contains(p.Titleofgenre)).ToList();
            List <Manufacture> Manufactures = _context.Manufactures.Where(p => manufactures.Contains(p.Titleofmanufactures)).ToList();
            List<Country> Country = _context.Countries.Where(p => regionRestrict.Contains(p.Titleofcountry)).ToList();
            Serie Series = _context.Series.SingleOrDefault(p => p.Titleofseries == series);
            if (Series == null)
            {

                Series = new Serie() { Titleofseries = series };
            }

         
            game.Titleofgame = titleofgame;
            game.Description = description;
            game.DateRelese = datarealese;
            game.Manufactures=Manufactures;
            game.Platforms=Platforms;
            game.Localizations=Localizations;
            game.Genres=Genres;
            game.Series=Series;


            _context.Entry(game).State = EntityState.Modified;
      
            _context.Games.Add(game);
     

            List<Image> images = new List<Image>();
            foreach (var item in filenames)
            {
                images.Add (new Image() { Url = item });


            }

            game.Products.Add(new Product { Game = game});
            _context.Publications.Add(new Publication { Game = game, Price = price, Comments = new List<Comment>(), Images=images });

         
            _context.SaveChanges();

            AverageRating();

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
            AverageRating();
        }

        public Publication GetPublication(string Titleofgame)

        {
            AverageRating();
            return _context.Publications.Include(p => p.Game).Include(p => p.Marks).Include(d => d.Comments).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(p => p.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p=>p.Images).Include(p => p.Comments).ThenInclude(d=>d.User).ThenInclude(d=>d.Avatar).Include(p=>p.Carts).FirstOrDefault(p=>p.Game.Titleofgame.Equals(Titleofgame));
        }

        public IEnumerable<Publication> GetManyPublication(string[] genres, string[] manufactures, string[] platforms, string[] localizations)
        {

            return _context.Publications.Include(p => p.Game).Include(p => p.Marks).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(p => p.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p=>p.Comments).Where(p=>p.Game.Genres.Any(d=>genres.Contains(d.Titleofgenre)) & p.Game.Manufactures.Any(d=>manufactures.Contains(d.Titleofmanufactures) & p.Game.Platforms.Any(d=>platforms.Contains(d.Titleofplatform)) & p.Game.Localizations.Any(d=>localizations.Contains(d.Titleoflocalization))  )).ToList();

        } 

        public IEnumerable<Publication> GetPublications(int page, out int totalitems, int size)
        {
           

            totalitems=_context.Publications.Count();

            return _context.Publications.Include(p=>p.Game).Include(p=>p.Marks).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(p => p.Game.RegionRestricts).Include(p=>p.Game.Genres).Include(p => p.Game.Series).Include(p => p.Comments).Skip((page - 1) * size).Take(size).ToList();
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

        //Для вычисления рейтинга, на основе выставленных пользователями оценок
        public void AverageRating()
        {

           
            foreach (var item in _context.Publications.Include(d => d.Marks).ToList())
            {
                if (item.Marks.Count() > 0) { 
               
                    item.Rating = item.Marks.Average(d => d.Numberofmark);

                    _context.Entry(item).State = EntityState.Modified;
                   
                    _context.SaveChanges();
                }


            }


        }

        public void AddMark(int idpublication, string username,double numberofmark)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            Publication publication = _context.Publications.AsNoTracking().Include(d=>d.Marks).AsNoTracking().FirstOrDefault(d => d.Id == idpublication);
            User user = _context.Users.AsNoTracking().Include(d=>d.Marks).AsNoTracking().FirstOrDefault(d => d.Login == username);
            Mark mark = _context.Marks.AsNoTracking().Include(d=>d.User).AsNoTracking().Include(d=>d.Publication).AsNoTracking().FirstOrDefault(d => d.idpublication == idpublication && d.User.Login == username);

            if (mark != null)
            {

                mark.Numberofmark = numberofmark;
                _context.Marks.Update(mark);
           
                _context.SaveChanges();
            }
            else {

             
                mark=new Mark() { Numberofmark=numberofmark, idpublication=publication.Id, iduser=user.Id };
                
                _context.Marks.Add(mark);
                _context.SaveChanges();
              
                user.Marks.Add(mark);

                

                _context.SaveChanges();

            }
          
            _context.SaveChanges();
      

        }

        public IEnumerable<Publication> GetAll(out int totalitems)
        {
            totalitems = _context.Publications.Count();
            return _context.Publications.Include(p => p.Game).Include(p => p.Marks).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(p => p.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p => p.Comments).ToList();
        }
    }
}
