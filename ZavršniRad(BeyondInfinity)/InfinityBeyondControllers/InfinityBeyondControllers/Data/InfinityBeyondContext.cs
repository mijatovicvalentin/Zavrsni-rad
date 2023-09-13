using InfinityBeyondControllers.Controllers;
using InfinityBeyondControllers.Models;
using Microsoft.EntityFrameworkCore;


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

    }

}