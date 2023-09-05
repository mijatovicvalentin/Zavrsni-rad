using InfinityBeyondControllers1.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityBeyondControllers1.Data
{
    public class InfinityBeyondContext : DbContext
    {
        public InfinityBeyondContext(DbContextOptions<InfinityBeyondContext> opcije)
            : base(opcije)
        {

        }

        public DbSet<Korisnik> Korisnik { get; set; }

    }
}