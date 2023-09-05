
using InfinityBeyondControllers1;
using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers1.Models
{
    public class Korisnik : Povezivanje
    {
        [Required]
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int? Oib { get; set; }
        public string? Email { get; set; }
    }
}