using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers.Models
{
    public abstract class Povezivanje
    {
        [Key]
        public int sifra { get; set; }
    }
}
