using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers.Models
{
    public class Korisnik : Povezivanje
    {
     
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Oib { get; set; }
        public string? Email { get; set; }

    }
}
