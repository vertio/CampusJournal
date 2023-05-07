using System;
using System.ComponentModel.DataAnnotations;

namespace CampusJournal.Models
{
    public class StudentsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole StudentIndexNumber jest wymagane.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "StudentIndexNumber musi mieć co najmniej 8 znaków.")]
        public string StudentIndexNumber { get; set; }

        [Required(ErrorMessage = "Pole imie jest wymagane.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Imie musi mieć co najmniej 2 litery, a maksymalnie 50.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nazwisko musi mieć co najmniej 2 litery, a maksymalnie 50.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Pole Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Nie prawidłowy format.")]
        public string email { get; set; }

        public string PhoneNumber {get; set;}

        [DataType(DataType.Date)]
        public DataType ReleaseDate { get; set; }

        [Required(ErrorMessage = "Pole Address jest wymagany")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pole City jest wymagany")]
        public string City { get; set; }
    }
}
