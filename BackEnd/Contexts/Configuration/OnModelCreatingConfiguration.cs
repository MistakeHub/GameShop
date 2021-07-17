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

            modelBuilder.Entity<Mark>().HasOne(p => p.User).WithMany(d => d.Marks).HasForeignKey(d=>d.idpublication);

            modelBuilder.Entity<Publication>().HasMany(p => p.Marks).WithOne(d => d.Publication).HasForeignKey(p => p.idpublication);

            modelBuilder.Entity<User>().HasOne(p => p.Avatar).WithMany(d => d.Users).HasForeignKey(d => d.Idavatar);

            modelBuilder.Entity<Image>().HasOne(p => p.Publication).WithMany(d => d.Images).HasForeignKey(p => p.Idpublication);


            modelBuilder
          .Entity<Game>()
          .HasMany(c => c.Localizations)
          .WithMany(s => s.Games)
          .UsingEntity<Product>(
             j =>
              j.HasOne(pt => pt.Localization)
              .WithMany(t => t.Products)
              .HasForeignKey(pt => pt.Idlocalization),
          j =>
              j.HasOne(pt => pt.Game)
              .WithMany(p => p.Products)
              .HasForeignKey(pt => pt.idgame),


          j =>
          {

              j.HasKey(t => new { t.idgame, t.Idmanufacture, t.Idgenre });
              j.ToTable("Products");
          }
      );

            modelBuilder
              .Entity<Game>()
              .HasMany(c => c.Platforms)
              .WithMany(s => s.Games)
              .UsingEntity<Product>(
                 j =>
                  j.HasOne(pt => pt.Platform)
                  .WithMany(t => t.Products)
                  .HasForeignKey(pt => pt.Idplatform),
              j =>
                  j.HasOne(pt => pt.Game)
                  .WithMany(p => p.Products)
                  .HasForeignKey(pt => pt.idgame),


              j =>
              {

                  j.HasKey(t => new { t.idgame, t.Idmanufacture, t.Idgenre });
                  j.ToTable("Products");
              }
          );


            modelBuilder
              .Entity<Game>()
              .HasMany(c => c.Genres)
              .WithMany(s => s.Games)
              .UsingEntity<Product>(
                 j =>
                  j.HasOne(pt => pt.Genre)
                  .WithMany(t => t.Products)
                  .HasForeignKey(pt => pt.Idgenre),
              j =>
                  j.HasOne(pt => pt.Game)
                  .WithMany(p => p.Products)
                  .HasForeignKey(pt => pt.idgame),


              j =>
              {

                  j.HasKey(t => new { t.idgame, t.Idmanufacture, t.Idgenre });
                  j.ToTable("Products");
              }
          );


            modelBuilder
                .Entity<Game>()
                .HasMany(c => c.RegionRestricts)
                .WithMany(s => s.Games)
                .UsingEntity<Product>(
                   j =>
                    j.HasOne(pt => pt.RegionRestrict)
                    .WithMany(t => t.Products)
                    .HasForeignKey(pt => pt.Idregionrestrict),
                j =>
                    j.HasOne(pt => pt.Game)
                    .WithMany(p => p.Products)
                    .HasForeignKey(pt => pt.idgame),


                j =>
                {

                    j.HasKey(t => new { t.idgame, t.Idmanufacture, t.Idgenre });
                    j.ToTable("Products");
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
                .UsingEntity<Product>(
                   j =>
                    j.HasOne(pt => pt.Manufacture)
                    .WithMany(t => t.Products)
                    .HasForeignKey(pt => pt.Idmanufacture),
                j =>
                    j.HasOne(pt => pt.Game)
                    .WithMany(p => p.Products)
                    .HasForeignKey(pt => pt.idgame),


                j =>
                {

                    j.HasKey(t => new { t.idgame, t.Idmanufacture, t.Idgenre });
                    j.ToTable("Products");
                }
            );


            modelBuilder.Entity<Product>()
           .HasKey(bc => new { bc.idgame });
            modelBuilder.Entity<Product>()
                .HasOne(bc => bc.Game)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.idgame);
            modelBuilder.Entity<Product>()
                .HasOne(bc => bc.RegionRestrict)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.Idregionrestrict);

            modelBuilder.Entity<Product>()
          .HasOne(bc => bc.Genre)
          .WithMany(b => b.Products)
          .HasForeignKey(bc => bc.Idgenre);

            modelBuilder.Entity<Product>()
          .HasOne(bc => bc.Localization)
          .WithMany(b => b.Products)
          .HasForeignKey(bc => bc.Idlocalization);

            modelBuilder.Entity<Product>()
          .HasOne(bc => bc.Manufacture)
          .WithMany(b => b.Products)
          .HasForeignKey(bc => bc.Idmanufacture);

            modelBuilder.Entity<Product>()
          .HasOne(bc => bc.Platform)
          .WithMany(b => b.Products)
          .HasForeignKey(bc => bc.Idplatform);



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

              j.HasKey(t => new { t.idpublication, t.idcart});
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
