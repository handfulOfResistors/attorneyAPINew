using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace attorneyApi.Models
{
    
    public class CourtCode
    {
        [Key]
        public string UniqueNumber { get; set; }
        public string SubjectType { get; set; }
        public string Year { get; set; }
        public string HourlyRate { get; set; }
    }
}
