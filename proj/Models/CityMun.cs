using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{

    public class CityMun
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Ime { get; set; } 
        
        public string ZIPcode { get; set; }
        [JsonIgnore]
        public List<MernoMesto> mernamesta { get; set; }
    }
}