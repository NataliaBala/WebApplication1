using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public enum CategoryModel
{
    [Display(Name = "Rodzina")]
    Family = 1,
    [Display (Name = "Znajoimi")]
    Friend = 2,
    [Display (Name = "Zawodowy")]
    Business = 3
}