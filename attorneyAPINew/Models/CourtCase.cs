using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace attorneyApi.Models
{
    
    public class CourtCase
    {
        public CourtCase()
        {
            CourtCode = new CourtCode();
        }

        [Key]
        public int CourtCaseId { get; set; }
        public string OfficeCode { get; set; }
        public string Associates { get; set; }
        public string Client { get; set; }
        public string Opponent { get; set; }






        [NotMapped]
        public CourtCode CourtCode { get; set; }
    }
}
