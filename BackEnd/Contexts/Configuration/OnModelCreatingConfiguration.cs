using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Contexts.Configuration
{
    public static class OnModelCreatingConfiguration
    {

        public static void OnModelCreating(this ModelBuilder modelBuilder)
        {
         
        
            modelBuilder.Entity<User>()
             .HasOne(a => a.Cart)
             .WithOne(a => a.User)
             .HasForeignKey<Cart>(c => c.Iduser);

            modelBuilder.Entity<User>()
           .HasOne(a => a.Status)
           .WithMany(a => a.Users)
           .HasForeignKey(c => c.Idstatus);

            modelBuilder.Entity<User>()
           .HasOne(a => a.Role)
           .WithMany(a => a.Users)
           .HasForeignKey(c => c.Idrole);

            modelBuilder.Entity<Publication>().HasOne(p => p.Game).WithOne(a => a.Publication).HasForeignKey<Game>(d => d.Idpublication);

            modelBuilder.Entity<Game>().HasOne(p => p.Publication).WithOne(a => a.Game).HasForeignKey<Publication>(d => d.idgame);

            modelBuilder.Entity<Mark>().HasOne(p => p.User).WithMany(d => d.Marks).HasForeignKey(d => d.idpublication);

            modelBuilder.Entity<Publication>().HasMany(p => p.Marks).WithOne(d => d.Publication).HasForeignKey(p => p.idpublication);

            modelBuilder.Entity<User>().HasOne(p => p.Avatar).WithMany(d => d.Users).HasForeignKey(d => d.Idavatar);

            modelBuilder.Entity<Image>().HasOne(p => p.Publication).WithMany(d => d.Images).HasForeignKey(p => p.Idpublication);

            modelBuilder.Entity<Comment>().HasOne(p => p.User).WithMany(d => d.Comments).HasForeignKey(d => d.Iduser);

            modelBuilder.Entity<User>().HasMany(p => p.Comments).WithOne(d => d.User).HasForeignKey(p => p.Iduser);


            modelBuilder.Entity<Comment>().HasOne(p => p.Publication).WithMany(d => d.Comments).HasForeignKey(d => d.Idpublication);

            modelBuilder.Entity<Publication>().HasMany(p => p.Comments).WithOne(d => d.Publication).HasForeignKey(p => p.Idpublication);









            modelBuilder
          .Entity<Game>()
          .HasMany(c => c.RegionRestricts)
          .WithMany(s => s.Games)
          .UsingEntity<Gameregionrestrict>(
             j =>
              j.HasOne(pt => pt.RegionRestrict)
              .WithMany(t => t.Gameregionrestricts)
              .HasForeignKey(pt => pt.RegionrestrictId),
          j =>
              j.HasOne(pt => pt.Game)
              .WithMany(p => p.Gameregionrestricts)
              .HasForeignKey(pt => pt.GameId),


          j =>
          {

              j.HasKey(t => new { t.GameId,  t.RegionrestrictId  });
              j.ToTable("Gameregionrestricts");
          }
      );

            modelBuilder
              .Entity<Game>()
              .HasMany(c => c.Platforms)
              .WithMany(s => s.Games)
              .UsingEntity<Gameplatform>(
                 j =>
                  j.HasOne(pt => pt.Platform)
                  .WithMany(t => t.Gameplatforms)
                  .HasForeignKey(pt => pt.PlatformId),
              j =>
                  j.HasOne(pt => pt.Game)
                  .WithMany(p => p.Gameplatforms)
                  .HasForeignKey(pt => pt.GameId),


              j =>
              {

                  j.HasKey(t => new { t.GameId, t.PlatformId, });
                  j.ToTable("Gameplatforms");
              }
          );


            modelBuilder
              .Entity<Game>()
              .HasMany(c => c.Genres)
              .WithMany(s => s.Games)
              .UsingEntity<Gamegenre>(
                 j =>
                  j.HasOne(pt => pt.Genre)
                  .WithMany(t => t.Gamegenres)
                  .HasForeignKey(pt => pt.GenreId),
              j =>
                  j.HasOne(pt => pt.Game)
                  .WithMany(p => p.Gamegenres)
                  .HasForeignKey(pt => pt.GameId),


              j =>
              {

                  j.HasKey(t => new { t.GameId,  t.GenreId });
                  j.ToTable("Gamegenres");
              }
          );


            modelBuilder
                .Entity<Game>()
                .HasMany(c => c.Localizations)
                .WithMany(s => s.Games)
                .UsingEntity<Gamelocalization>(
                   j =>
                    j.HasOne(pt => pt.Localization)
                    .WithMany(t => t.Gamelocalizations)
                    .HasForeignKey(pt => pt.LocalizationId),
                j =>
                    j.HasOne(pt => pt.Game)
                    .WithMany(p => p.Gamelocalizations)
                    .HasForeignKey(pt => pt.GameId),


                j =>
                {

                    j.HasKey(t => new { t.GameId, t.LocalizationId});
                    j.ToTable("Gamelocalizations");
                }
            );



            modelBuilder.Entity<Game>()
       .HasOne(a => a.Series)
       .WithMany(a => a.Games)
       .HasForeignKey(c => c.Idseriesofgame);

            modelBuilder
                .Entity<Game>()
                .HasMany(c => c.Manufactures)
                .WithMany(s => s.Games)
                .UsingEntity<Gamemanufacture>(
                   j =>
                    j.HasOne(pt => pt.Manufacture)
                    .WithMany(t => t.Gamemanufactures)
                    .HasForeignKey(pt => pt.ManufactureId),
                j =>
                    j.HasOne(pt => pt.Game)
                    .WithMany(p => p.Gamemanufactures)
                    .HasForeignKey(pt => pt.GameId).OnDelete(DeleteBehavior.Cascade),



                j =>
                {

                    j.HasKey(t => new { t.GameId, t.ManufactureId });
                    j.ToTable("Gamemanufactures");
                }
            );




           

           
            



            modelBuilder.Entity<Cart>()
              .HasMany(c => c.Publications)
              .WithMany(s => s.Carts)
              .UsingEntity<Gamecart>(
                 j =>
                  j.HasOne(pt => pt.Publication)
                  .WithMany(t => t.GameCarts)
                  .HasForeignKey(pt => pt.idpublication),
              j =>
                  j.HasOne(pt => pt.Cart)
                  .WithMany(p => p.Gamecart)
                  .HasForeignKey(pt => pt.idcart),


              j =>
              {

                  j.HasKey(t => new { t.idpublication, t.idcart });
                  j.ToTable("Gamecarts");
              }
          );
         
            
            modelBuilder.Entity<Cart>().HasKey(p => p.Id);
            modelBuilder.Entity<Comment>().HasKey(p => p.Id);
            modelBuilder.Entity<Country>().HasKey(p => p.Id);
            modelBuilder.Entity<Game>().HasKey(p => p.Id);
            modelBuilder.Entity<Genre>().HasKey(p => p.Id);
            modelBuilder.Entity<Localization>().HasKey(p => p.Id);
            modelBuilder.Entity<Manufacture>().HasKey(p => p.Id);

            modelBuilder.Entity<Platform>().HasKey(p => p.Id);
            modelBuilder.Entity<Role>().HasKey(p => p.Id);
            modelBuilder.Entity<Publication>().HasKey(p => p.Id);
            modelBuilder.Entity<Serie>().HasKey(p => p.Id);
            modelBuilder.Entity<Statuse>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(p => p.Id);

        }
    }
}