﻿using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondSwagger.Models
{
    public class Korisnik : Povezivanje
    {
        [Required(ErrorMessage = "Naziv obavezno")]

        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Oib { get; set; }
        public string? Email { get; set; }

    }
}
