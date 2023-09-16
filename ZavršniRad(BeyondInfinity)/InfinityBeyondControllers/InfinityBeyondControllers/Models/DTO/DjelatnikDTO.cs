using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBeyondControllers.Models.DTO
{
    public class DjelatnikDTO
    {
        public int id { get; set; }
        public int? ime { get; set; }
        public int? prezime { get; set; }
        public int? oib { get; set; }
        public int? kontakt { get; set; }
        public int? jedinstvenibroj { get; set; }
        public vrsta_djelatnika? vrsta_djelatnika { get; set; }


    }
}
