using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class AirQdata
    {
        [Key]
        public int ID { get; set; }        
        public int Qindex { get; set; }
        public double PMtwo { get; set; }
        [JsonIgnore]
        public List<MernoMesto> mernamesta { get; set; }

    }
}