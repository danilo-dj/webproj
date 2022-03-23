using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class WAirContext: DbContext
    {
        public DbSet<Weatherdata> weatherdatas { get; set; }
        public DbSet<AirQdata> airqdatas { get; set; }
        public DbSet<CityMun> citymuns { get; set; }
        public DbSet<MernoMesto> mernamesta { get; set; }

        public WAirContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}