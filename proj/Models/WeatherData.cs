using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Weatherdata
    {
       [Key]
       public int ID { get; set; }  
       [MaxLength(50)]
       [Required]
       public string Ukratko { get; set; }   
       [Required]
       public double Temperature { get; set; }
       [Required] 
       public double Humidity { get; set; } 
       [JsonIgnore]
       public List<MernoMesto> mernamesta { get; set; }      
        
    }
}