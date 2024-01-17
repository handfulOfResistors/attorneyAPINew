using System.Collections.Generic;
using System;
using System.Collections;
using attorneyApi.Models;
using System.Linq;

namespace attorneyApi.Repository.Interface
{
    public interface ICourtCaseRepository
    {
        IQueryable<CourtCase> Get();
    }
}
