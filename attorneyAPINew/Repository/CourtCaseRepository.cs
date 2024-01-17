using attorneyApi.Models;
using attorneyApi.Repository.Interface;
using attorneyAPINew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace attorneyApi.Repository
{
    public class CourtCaseRepository : ICourtCaseRepository
    {
        public attorneyPetrovicContext context;
        public virtual DbSet<CourtCase> CourtCases { get; set; }

        public CourtCaseRepository()
        {
            context = new attorneyPetrovicContext();
            CourtCases = context.CourtCases;
        }
        public IQueryable<CourtCase> Get()
        {

            return this.context.CourtCases.Include("CourtCase");
        }


    }
}
