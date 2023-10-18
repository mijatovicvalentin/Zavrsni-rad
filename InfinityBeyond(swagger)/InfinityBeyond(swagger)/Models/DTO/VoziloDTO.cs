namespace InfinityBeyondSwagger.Models.DTO
{
    public class VoziloDTO
{

        public int id { get; set; }
        public string? naziv { get; set; }
        public decimal? cijena { get; set; }
        public DateTime? datum_proizvodnje { get; set; }
        public string? djelatnik { get; set; }
        public string tezina { get; set; }

        public int djelatnik_sifra { get; set; }



    }


}
