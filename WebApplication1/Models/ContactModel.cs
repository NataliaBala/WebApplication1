using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set;  }
    
    [Required(ErrorMessage = "Musisz podać imię!")]
    [MaxLength(length: 20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków!")]
    [MinLength(length: 2)]
    public string FirstName { get; set;  }
    
    [Required(ErrorMessage = "Musisz podać Nazwisko!")]
    [MaxLength(length: 50, ErrorMessage = "Nazwisko nie może być dłuższe niż 20 znaków!")]
    [MinLength(length: 2)]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly BirthDay { get; set; }
    
    [Phone]
    [RegularExpression(pattern:"\\d\\d\\d-\\d\\d\\d-\\d\\d\\d", ErrorMessage = "Podaj według schematu: xxx-xxx-xxx")]
    public string PhoneNumber { get; set; }
    
}