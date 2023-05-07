using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampusJournal.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentIndexNumber { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public StudentsViewModel Students { get; set; }
    }
}
