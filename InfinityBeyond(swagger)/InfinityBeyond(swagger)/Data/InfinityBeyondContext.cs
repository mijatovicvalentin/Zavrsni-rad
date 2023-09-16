using InfinityBeyondControllers.Controllers;
using InfinityBeyondControllers.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace InfinityBeyondControllers.Data
{
    public class InfinityBeyondContext : DbContext
    {
        public InfinityBeyondContext(DbContextOptions<InfinityBeyondContext> options)
            : base(options)
        {


        }

        public DbSet<Korisnik> Korisnik { get; set; }

        public DbSet<Usluga> Usluga { get; set; }

        public DbSet<Vrsta_djelatnika> Vrsta_Djelatnika { get; set; }

        public DbSet<Djelatnik> Djelatnik { get; set; }

        public DbSet<Vozilo> Vozilo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Djelatnik>().HasOne(v => v.Vrsta_djelatnika);


        }
    }

}
