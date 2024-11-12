using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family, 
    [Display(Name = "Przyjaciele", Order = 3)]
    Friend, 
    [Display(Name = "Kontakt zawodowy", Order = 2)]
    Business,
}