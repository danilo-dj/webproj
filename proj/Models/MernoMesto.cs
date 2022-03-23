using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class MernoMesto
    {
        [Key]
        public int ID { get; set; } 
        [Required]
        [MaxLength(50)]         
        public string Ime { get; set; }

        public Weatherdata weatherdata { get; set; }

        public AirQdata airqdata { get; set; }

        public CityMun citymun { get; set; }
    }
}