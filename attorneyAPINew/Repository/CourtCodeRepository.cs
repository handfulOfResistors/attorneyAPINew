using attorneyApi.Models;
using attorneyApi.Repository.Interface;
using attorneyAPINew.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace attorneyAPINew.Repository
{
    public class CourtCodeRepository : ICourtCodeRepository
    {

        public attorneyPetrovicContext context;
        public virtual DbSet<CourtCode> CourtCodes { get; set; }

        public CourtCodeRepository() 
        {
            context = new attorneyPetrovicContext();
            CourtCodes = context.CourtCodes;
        }    
        public IQueryable<CourtCode> Get()
        {
            return this.context.CourtCodes.Include("CourtCode");
        }



    }
}
