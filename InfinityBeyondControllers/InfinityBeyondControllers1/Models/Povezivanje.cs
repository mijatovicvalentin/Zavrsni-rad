using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers1.Models
{
    public abstract class Povezivanje
    {
        [Key]
        public int Sifra { get; set; }
    }
}