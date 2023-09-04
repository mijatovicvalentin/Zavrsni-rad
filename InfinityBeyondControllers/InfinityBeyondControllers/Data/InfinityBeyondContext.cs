using InfinityBeyondControllers.Controllers;
using InfinityBeyondControllers.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityBeyondControllers.Data
{
    public class InfinityBeyondContext : DbContext
    {
        public InfinityBeyondContext(DbContextOptions<InfinityBeyondContext> opcije)
            : base(opcije)
        {

        }

        public DbSet<KorisnikController> korisnik { get; set; }

    }
}