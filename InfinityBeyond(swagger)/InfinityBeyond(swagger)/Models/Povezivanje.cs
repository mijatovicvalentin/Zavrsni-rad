using System.ComponentModel.DataAnnotations;

namespace InfinityBeyondSwagger.Models
{
    public abstract class Povezivanje
    {
        [Key]
        public int id { get; set; }
    }
}
