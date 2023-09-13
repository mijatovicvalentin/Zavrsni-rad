using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers.Models
{
    public class Korisnik : Povezivanje
    {
     
        public string? ime { get; set; }
        public string? prezime { get; set; }
        public string? oib { get; set; }
        public string? email { get; set; }

    }
}
