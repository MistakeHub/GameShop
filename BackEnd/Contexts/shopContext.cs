using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Proxies;

using BackEnd.Contexts.Configuration;

namespace BackEnd
{
    public class shopContext:DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Manufacture> Manufactures { get; set; }

        public DbSet<Gamemanufacture> Gamemanufactures { get; set; }

        public DbSet<Gameplatform> Gameplatforms { get; set; }

        public DbSet<Gameregionrestrict> Gameregionrestricts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Gamelocalization> Gamelocalizations { get; set; }

        public DbSet<Gamegenre> Gamegenres { get; set; }

        public DbSet<Gamecart> Gamecarts { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Localization> Localizations { get; set; }

        public DbSet<Platform> Platforms { get; set; }     

        public DbSet<Image> Images { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Serie> Series { get; set; }

        public DbSet<Statuse> Statuses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public shopContext(DbContextOptions<shopContext> options):base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.Write);



            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
          
         


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.OnModelCreating();



        }
      
    }
}
