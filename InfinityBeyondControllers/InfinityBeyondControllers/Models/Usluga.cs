using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers.Models
{
    public class Usluga : Povezivanje
    {
        public string? Naziv { get; set; }
        public string? Destinacija { get; set; }
        public int nacin_placanja { get; set; }
        public decimal? Cijena { get; set; }
        public int broj_mjesta { get; set; }
    }
}
