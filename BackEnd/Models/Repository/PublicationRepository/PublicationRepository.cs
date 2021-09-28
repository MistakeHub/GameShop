using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models.SaveToFile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackEnd.Models.Repository.PublicationRepository
{
    public class PublicationRepository :  IPublicationRepository
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
            comment.DateofAddComment = DateTime.Now;
            user.Comments.Add(comment);
            _context.Users.Update(user);
            _context.SaveChanges();
            Publication publication = _context.Publications.Where(d => d.IsDeleted == false).Include(d => d.Comments).SingleOrDefault(p => p.Id == idpublication);
            publication.Comments.Add(comment);
            _context.Publications.Update(publication);
            _context.SaveChanges();
            return _context.Publications.Include(d => d.Comments).ThenInclude(d=>d.User).ThenInclude(d=>d.Avatar).SingleOrDefault(p => p.Id == idpublication).Comments;
        }

        public void AddPublication(IList<IFormFile> filenames,string filepath, string titleofgame, string description, DateTime datarealese, string[] platforms, string[] localizations, string[] genres, string[] manufactures, string[] regionRestrict, string series, double price)
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
            _context.Games.Add(game);
            _context.SaveChanges();
            var ent = _context.ChangeTracker.Entries();
            List<Gamegenre> gamegenres = new List<Gamegenre>();
            foreach (var item in Genres)
            {
                ent= Enumerable.Empty<EntityEntry>(); ;
                Gamegenre product = new Gamegenre() { GameId= game?.Id, GenreId=item?.Id };
                _context.ChangeTracker.Clear();
             

                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                game.Genres.Add(item);
                game.Gamegenres.Add(product);
                _context.SaveChanges();
                gamegenres.Add(product);




            }

            List<Gameregionrestrict> gameregionrestricts = new List<Gameregionrestrict>();
            foreach (var item in Country)
            {
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gameregionrestrict product = new Gameregionrestrict() { GameId = game?.Id, RegionrestrictId = item?.Id };
                _context.ChangeTracker.Clear();


                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                game.RegionRestricts.Add(item);
                game.Gameregionrestricts.Add(product);
                _context.SaveChanges();

                gameregionrestricts.Add(product);




            }
            List<Gamemanufacture> gamemanufactures = new List<Gamemanufacture>();

            foreach (var item in Manufactures)
            {
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gamemanufacture product = new Gamemanufacture() { GameId = game?.Id, ManufactureId = item?.Id };
                _context.ChangeTracker.Clear();
              
              
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                game.Manufactures.Add(item);
                game.Gamemanufactures.Add(product);
                _context.SaveChanges();

                gamemanufactures.Add(product);

        
            }
            List<Gamelocalization> gamelocaliaztions = new List<Gamelocalization>();

            foreach (var item in Localizations)
            {
                ent = Enumerable.Empty<EntityEntry>(); ;
                Gamelocalization product = new Gamelocalization() { GameId = game?.Id, LocalizationId = item?.Id };
                _context.ChangeTracker.Clear();
             
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                game.Localizations.Add(item);
                 game.Gamelocalizations.Add(product);
                _context.SaveChanges();


                gamelocaliaztions.Add(product);
           

            }

            List<Gameplatform> gameplatforms = new List<Gameplatform>();
            foreach (var item in Platforms)
            {
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gameplatform product = new Gameplatform() { GameId = game?.Id, PlatformId = item?.Id };
                _context.ChangeTracker.Clear();
                _context.Entry(item).State = EntityState.Modified;

                _context.Entry(product).State = EntityState.Added;
                game.Platforms.Add(item);

                game.Gameplatforms.Add(product);
                _context.SaveChanges();


                gameplatforms.Add(product);
            

            }
           

            List<Image> images = new List<Image>();
            foreach (var item in filenames)
            {

                images.Add(new Image() { Url = $"https://localhost:44303/getImage/{game.Titleofgame}/{item.FileName}", Filename=item.FileName  });


            }

            FileSave<Game>.Uploads(filenames, filepath, $"/images/{titleofgame.Replace(" ", "")}/");


            _context.Entry(game).State = EntityState.Modified;
            _context.Publications.Add(new Publication { Game = game, Price = price, Comments = new List<Comment>(), Images = images, IsDeleted=false });
    
            _context.SaveChanges();



        }





        public void EditPublication(int id, IList<IFormFile> filenames, string filepath, string titleofgame, string description, DateTime datarealese, string[] platforms, string[] localizations, string[] genres, string[] manufactures, string[] regionRestrict, string series, double price)
        {
            
            Publication publication = _context.Publications.Include(p => p.Game).Include(p => p.Marks).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(d => d.Game.Platforms).Include(d => d.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p => p.Comments).Include(d => d.Images).FirstOrDefault(d => d.Id == id); ;
            List<Platform> Platforms = _context.Platforms.Where(p => platforms.Contains(p.Titleofplatform)).ToList();
            List<Localization> Localizations = _context.Localizations.Where(p => localizations.Contains(p.Titleoflocalization)).ToList();
            List<Genre> Genres = _context.Genres.Where(p => genres.Contains(p.Titleofgenre)).ToList();
            List<Manufacture> Manufactures = _context.Manufactures.Where(p => manufactures.Contains(p.Titleofmanufactures)).ToList();
            List<Country> Country = _context.Countries.Where(p => regionRestrict.Contains(p.Titleofcountry)).ToList();
            Serie Series = _context.Series.SingleOrDefault(p => p.Titleofseries == series);
            string OldTitle = publication.Game.Titleofgame;
            var p = publication.Game.Genres.FirstOrDefault(d => d.Id == 1);

     



         


            var ent = _context.ChangeTracker.Entries();

            foreach (var item in Platforms)
            {

                if (publication.Game.Platforms.Any(d => d.Id == item.Id)) continue;
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gameplatform product = new Gameplatform() { GameId = publication.Game?.Id, PlatformId = item?.Id };
                _context.ChangeTracker.Clear();


                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;


                publication.Game.Platforms.Add(item);
                publication.Game.Gameplatforms.Add(product);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();

            }
            _context.ChangeTracker.Clear();
            foreach (var item in Country)
            {
                if (publication.Game.RegionRestricts.Any(d => d.Id == item.Id)) continue;
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gameregionrestrict product = new Gameregionrestrict() { GameId = publication.Game?.Id, RegionrestrictId = item?.Id };
                _context.ChangeTracker.Clear();


                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                publication.Game.RegionRestricts.Add(item);
                publication.Game.Gameregionrestricts.Add(product);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();

            }

            _context.ChangeTracker.Clear();
            foreach (var item in Manufactures)
            {
                if (publication.Game.Manufactures.Any(d => d.Id == item.Id))
                    continue;
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gamemanufacture product = new Gamemanufacture() { GameId = publication.Game?.Id, ManufactureId = item?.Id };
                _context.ChangeTracker.Clear();


                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                publication.Game.Manufactures.Add(item);
                publication.Game.Gamemanufactures.Add(product);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }
            _context.ChangeTracker.Clear();

            foreach (var item in Localizations)
            {
                if (publication.Game.Localizations.Any(d => d.Id == item.Id)) continue;
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gamelocalization product = new Gamelocalization() { GameId = publication.Game?.Id, LocalizationId = item?.Id };
                _context.ChangeTracker.Clear();


                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                publication.Game.Localizations.Add(item);
                publication.Game.Gamelocalizations.Add(product);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }
            _context.ChangeTracker.Clear();

            foreach (var item in Genres)
            {
                if (publication.Game.Genres.Any(d => d.Id == item.Id)) continue;
                ent = Enumerable.Empty<EntityEntry>(); ;

                Gamegenre product = new Gamegenre() { GameId = publication.Game?.Id, GenreId = item?.Id };
                _context.ChangeTracker.Clear();


                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(product).State = EntityState.Added;
                publication.Game.Genres.Add(item);
                publication.Game.Gamegenres.Add(product);
                _context.SaveChanges();
                _context.ChangeTracker.Clear();
            }
            // Тут происходит удаление. Сначала мы удаляем из связной таблицы, затем удаляем из связной сущности
            IEnumerable<int> listofdeleteplatforms = publication.Game.Platforms.Select(d => d.Id).Except(Platforms.Select(d => d.Id));
      
            if (listofdeleteplatforms.Count() != 0) {

                _context.Gameplatforms.RemoveRange(_context.Gameplatforms.Where(d => d.GameId == publication.idgame && listofdeleteplatforms.Contains((int)d.PlatformId)));
                _context.SaveChanges();
            }



            IEnumerable<int> listofdeletelocalizations = publication.Game.Localizations.Select(d => d.Id).Except(Localizations.Select(p => p.Id));
            if (listofdeletelocalizations.Count() != 0) {

                _context.Gamelocalizations.RemoveRange(_context.Gamelocalizations.Where(d => d.GameId == publication.idgame && listofdeletelocalizations.Contains((int)d.LocalizationId)));
                _context.SaveChanges();
            }



            IEnumerable<int> listofdeletegenres = publication.Game.Genres.Select(d => d.Id).Except(Genres.Select(d => d.Id));
            if (listofdeletegenres.Count() !=0)
            {
                _context.Gamegenres.RemoveRange(_context.Gamegenres.Where(d => d.GameId == publication.idgame && listofdeletegenres.Contains((int)d.GenreId)));
      
                _context.SaveChanges();
            }


            IEnumerable<int> listofdeletemanufactures = publication.Game.Manufactures.Select(d => d.Id).Except(Manufactures.Select(p => p.Id));
            if (listofdeletemanufactures.Count() != 0) {

          
                _context.Gamemanufactures.RemoveRange(_context.Gamemanufactures.Where(d => d.GameId == publication.idgame && listofdeletemanufactures.Contains((int)d.ManufactureId)));
                _context.SaveChanges();
            }



            IEnumerable<int> listofdeletecountries = publication.Game.RegionRestricts.Select(d => d.Id).Except(Country.Select(d => d.Id));
            if (listofdeletecountries.Count() != 0) {


                _context.Gameregionrestricts.RemoveRange(_context.Gameregionrestricts.Where(d => d.GameId == publication.idgame && listofdeletecountries.Contains((int)d.RegionrestrictId)));
                _context.SaveChanges();
            }

            ent = Enumerable.Empty<EntityEntry>(); ;

            if (Series == null)
            {

                Series = new Serie() { Titleofseries = series };
                _context.Entry(Series).State = EntityState.Added;
                publication.Game.Series = Series;
            }

            if (OldTitle != titleofgame) {

                FileSave<Publication>.RemoveDirectory(filepath, $"/images/{OldTitle.Replace(" ", "")}");

                _context.Images.RemoveRange(_context.Images.Where(d=>d.Idpublication==publication.Id));
                publication.Images.Clear();

                _context.SaveChanges();
            }
            List<IFormFile> addedfiles = new List<IFormFile>();
            List<Image> images = new List<Image>();
            foreach (var item in filenames)
            {
                if (publication.Images.Any(d => d.Filename == item.FileName)) { continue; }

                images.Add(new Image() { Url = $"https://localhost:44303/getImage/{titleofgame.Replace(" ", "")}/{item.FileName}", Filename = item.FileName, Publication=publication });
                addedfiles.Add(item);
                _context.SaveChanges();

            }
            publication.Images.AddRange(images);
            IEnumerable<string> listofdeleteimages = publication.Images.Select(d => d.Filename).Except(filenames.Select(d => d.FileName));

            if (listofdeleteimages.Count() != 0)
            {
                FileSave<Publication>.RemoveImages(listofdeleteimages.ToList(), filepath, $"/images/{titleofgame.Replace(" ", "")}/");
           
                _context.Images.RemoveRange(publication.Images.Where(d => listofdeleteimages.Contains(d.Filename)));

                _context.SaveChanges();


            }


            publication.Game.Titleofgame = titleofgame;
            publication.Game.Description = description;
            publication.Game.DateRelese = datarealese;
            publication.Price = price;
        
       
            _context.Entry(publication.Game).State = EntityState.Modified;
            FileSave<Publication> .Uploads(addedfiles, filepath, $"/images/{titleofgame.Replace(" ", "")}/");
            _context.Publications.Update(publication);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            AverageRating();
        }

        public Publication GetPublicationbyTitle(string Titleofgame)

        {
            AverageRating();
            return _context.Publications.Where(d => d.IsDeleted == false).Include(p => p.Game).Include(p => p.Marks).Include(d => d.Comments).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(p => p.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p => p.Images).Include(p => p.Comments).ThenInclude(d => d.User).ThenInclude(d => d.Avatar).Include(p => p.Carts).FirstOrDefault(p => p.Game.Titleofgame.Equals(Titleofgame));
        }

        public IEnumerable<Publication> GetManyPublication(string[] genres, string[] manufactures, string[] platforms, string[] localizations, int pricefrom, int priceto)
        {

            return _context.Publications.Where(d => d.IsDeleted == false).Include(p => p.Game).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(d=>d.Images).
                Include(p => p.Game.Genres).Include(p => p.Game.Series).IgnoreAutoIncludes().Where(d=> d.Price >= pricefrom && d.Price <= priceto && d.Game.Localizations.Any(p=>localizations.Contains(p.Titleoflocalization))&&d.Game.Genres.Any(p=> genres.Contains(p.Titleofgenre) ) && d.Game.Platforms.Any(p=>platforms.Contains(p.Titleofplatform)) && d.Game.Manufactures.Any(p=>manufactures.Contains(p.Titleofmanufactures))).AsSplitQuery().ToList();

        }

        public IEnumerable<Publication> GetPublications(int page, out int totalitems, int size)
        {


            totalitems = _context.Publications.Where(d => d.IsDeleted == false).Count();



            return _context.Publications.Where(d => d.IsDeleted == false).Include(p => p.Game).Include(p => p.Marks).Include(d => d.Images).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(p => p.Game.Platforms).Include(p => p.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p => p.Comments).Skip((page - 1) * size).Take(size).ToList();
        }

        public IEnumerable RemoveComment(int id,int idpublication)
        {
            var remove = _context.Comments.SingleOrDefault(p => p.Id == id);
            
            _context.Remove(remove);
            _context.SaveChanges();
            Publication publication = _context.Publications.Include(d => d.Comments).ThenInclude(d => d.User).ThenInclude(d => d.Avatar).SingleOrDefault(p => p.Id == idpublication);
            return publication.Comments;
        }

        public void RemovePublication(int id)
        {
            var remove = _context.Publications.SingleOrDefault(p => p.Id == id);
            remove.IsDeleted = true;
            _context.Publications.Update(remove);
            _context.SaveChanges();
        }

        //Для вычисления рейтинга, на основе выставленных пользователями оценок
        public void AverageRating()
        {


            foreach (var item in _context.Publications.Include(d => d.Marks).Include(d => d.Game).Include(d => d.Game.Platforms).ToList())
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
            return _context.Publications.Include(p => p.Game).Where(d => d.IsDeleted == false).Include(p => p.Marks).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(d=>d.Game.Platforms).Include(d=>d.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p => p.Comments).ToList();
        }

        public Publication GetPublicationbyId(int id)
        {
           return  _context.Publications.Where(d => d.IsDeleted == false).Include(p => p.Game).Include(p => p.Marks).Include(p => p.Game.Localizations).Include(p => p.Game.Manufactures).Include(d => d.Game.Platforms).Include(d => d.Game.RegionRestricts).Include(p => p.Game.Genres).Include(p => p.Game.Series).Include(p => p.Comments).Include(d=>d.Images).FirstOrDefault(d=>d.Id==id) ;
        }

        public async void SaveToJson()
        {
            await FileSave < Game > .SaveToJson("Games.json", _context.Games);
           
        }

        public void LoadfromJson()
        {
            IEnumerable<Game> Game = FileSave<Game>.LoadFromJson("Games.json");

            _context.Games.AddRange(Game);
            _context.SaveChanges();
        }

        public void RemoveAll()
        {
            IEnumerable<Publication> remove = _context.Publications.Where(d => d.Id != 0);
          foreach(var item in remove)
            {
                item.IsDeleted = true;
                _context.Publications.Update(item);
            }
          
            _context.SaveChanges();
        }


    }
}
