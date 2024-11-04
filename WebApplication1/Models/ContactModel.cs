using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class ContactModel
    {
        [HiddenInput]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Musisz wpisać!")]
        [MaxLength(length: 20, ErrorMessage = "Za dużo znaków!")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Musisz wpisać!")]
        [MaxLength(length: 50, ErrorMessage = "Za dużo znaków!")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        
        [EmailAddress(ErrorMessage = "Zły email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Phone(ErrorMessage = "Zły numer telefonu!")]
        [Display(Name = "Numer telefonu")]
        [RegularExpression("\\d\\d\\d \\d\\d\\d \\d\\d\\d", ErrorMessage = "FORMAT: XXX XXX XXX!")]
        public string PhoneNumber { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateOnly BirthDate { get; set; }

        [Display(Name = "Ważność")]
        public Priority Priority { get; set; }
        
        public CategoryModel Category { get; set; }
    }
}