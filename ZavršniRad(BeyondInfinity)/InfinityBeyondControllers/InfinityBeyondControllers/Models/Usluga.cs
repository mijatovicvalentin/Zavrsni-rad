using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondControllers.Models
{
    public class Usluga : Povezivanje
    {
        public string? naziv { get; set; }
        public string? destinacija { get; set; }
        public int nacin_placanja { get; set; }
        public decimal? cijena { get; set; }
        public int broj_mjesta { get; set; }
    }
}
