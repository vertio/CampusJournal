using System.ComponentModel.DataAnnotations;

namespace CampusJournal.Models
{
    public class StudentsViewModel
    {
        public int Id { get; set; }
        public string StudentIndexNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string PhoneNumber {get; set;}
        [DataType(DataType.DateTime)]
        public DataType DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
