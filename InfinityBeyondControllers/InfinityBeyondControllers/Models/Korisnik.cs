using InfinityBeyondControllers.Models;
using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers.Models
{
    public class Smjer : Povezivanje
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int?  Oib { get; set; }
        public string? Email { get; set; }

    }
}