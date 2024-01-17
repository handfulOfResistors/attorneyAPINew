using attorneyApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace attorneyApi.Repository.Interface
{
    public interface ICourtCodeRepository
    {
        public interface ICourtCaseRepository
        {
            IQueryable<CourtCase> Get();
        }
    }
}




