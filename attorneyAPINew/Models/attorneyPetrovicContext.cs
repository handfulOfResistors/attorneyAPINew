using attorneyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace attorneyAPINew.Models
{
    public class attorneyPetrovicContext : DbContext
    {
        public attorneyPetrovicContext() { }
        public attorneyPetrovicContext(DbContextOptions<attorneyPetrovicContext> options)
            :base(options)
        {
        }    
        public virtual DbSet<CourtCase>CourtCases { get; set; }
        public virtual DbSet<CourtCode>CourtCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {




            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }






    }
}
