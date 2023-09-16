using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityBeyondControllers.Models
{
    public class Vozilo
    {

        public string naziv { get; set; }
        public decimal cijena { get; set; }
        public DateTime datum_proizvodnje { get; set; }
        [ForeignKey("Djelatnik")]
        public Djelatnik djelatnik { get; set; }
        public string tezina { get; set; }

    }
}
