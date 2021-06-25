using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd
{
    public class shopContext:DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Gamecart> Gamecarts { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Localization> Localizations { get; set; }

        public DbSet<Manufacture> Manufactures { get; set; }

  

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<Statuse> Statuses { get; set; }

        public DbSet<User> Users { get; set; }

        public shopContext(DbContextOptions<shopContext> options):base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
                .UsingEntity < Product > (
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
                   
                    j.HasKey(t => new { t.idgame, t.Idmanufacture , t.Idgenre});
                    j.ToTable("Products");
                }
            );


            modelBuilder.Entity<Product>()
           .HasKey(bc => new { bc.idgame});
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


            modelBuilder.Entity<Gamecart>()
      .HasKey(bc => new { bc.Idproduct });


            modelBuilder.Entity<Gamecart>()
             .HasOne(bc => bc.Product)
             .WithOne(b => b.Gamecart)
             .HasForeignKey<Product>(bc => bc.Idgamecart);
            modelBuilder.Entity<Gamecart>()
                .HasOne(bc => bc.Cart)
                .WithMany(b => b.Gamecart)
                .HasForeignKey(bc => bc.idcart);

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
