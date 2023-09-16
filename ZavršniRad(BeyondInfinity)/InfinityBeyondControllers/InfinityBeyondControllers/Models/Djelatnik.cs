using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBeyondControllers.Models
{
    public class Djelatnik : Povezivanje
    {

        public int? ime { get; set; }
        public int? prezime { get; set; }
        public int? oib { get; set; }
        public int? kontakt { get; set; }
        public int? jedinstvenibroj { get; set; }
        [ForeignKey("vrsta_djelatnika")]

        public vrsta_djelatnika? vrsta_djelatnika { get; set; }







    }
}
