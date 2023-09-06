using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers.Models
{
    public class Usluga : Povezivanje
    {
        [Required]
        public string? Naziv { get; set; }
        public string? Destinacija { get; set; }
        public int NacinPlacanja { get; set; }
        public decimal? Cijena { get; set; }
        public int BrojMjesta { get; set; }
    }
}
