namespace InfinityBeyondControllers
{
    public class Usluga : Povezivanje
    {
        public string Naziv { get; set; }
        public string Destinacija { get; set; }
        public int NacinPlacanja { get; set; }
        public decimal Cijena { get; set; }
        public int BrojMjesta { get; set; }
    }
}
