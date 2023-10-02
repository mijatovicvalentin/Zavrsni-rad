using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondSwagger.Models
{
    public class Usluga : Povezivanje
    {
        public string? Naziv { get; set; }
        public string? destinacija { get; set; }
        public int nacin_placanja { get; set; }
        public decimal? cijena { get; set; }
        public int broj_mjesta { get; set; }
    }
}
