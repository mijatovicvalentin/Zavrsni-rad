using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBeyondSwagger.Models
{
    public class Djelatnik : Povezivanje
    {

        public string? ime { get; set; }
        public string? prezime { get; set; }
        public string? oib { get; set; }
        public string? kontakt { get; set; }
        public int? jedinstvenibroj { get; set; }


        [ForeignKey("vrsta_djelatnika")]
        public Vrsta_djelatnika? Vrsta_djelatnika { get; set; }







    }
}
