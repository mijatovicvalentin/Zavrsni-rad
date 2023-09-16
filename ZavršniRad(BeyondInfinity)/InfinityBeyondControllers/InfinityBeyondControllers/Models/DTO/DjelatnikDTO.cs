using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBeyondControllers.Models.DTO
{
    public class DjelatnikDTO
    {
        public int id { get; set; }
        public string? ime { get; set; }
        public string? prezime { get; set; }
        public string oib { get; set; }
        public string? kontakt { get; set; }
        public int? jedinstvenibroj { get; set; }
        public Vrsta_djelatnika? vrsta_djelatnika { get; set; }


    }
}
