﻿using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBeyondSwagger.Models
{
    public class Vozilo : Povezivanje
    {

        public string naziv { get; set; }
        public decimal cijena { get; set; }
        public DateTime datum_proizvodnje { get; set; }
        [ForeignKey("Djelatnik")]
        public Djelatnik djelatnik { get; set; }
        public string tezina { get; set; }

    }
}
