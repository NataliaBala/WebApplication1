using System.ComponentModel.DataAnnotations.Schema;

namespace Zaliczenie.Models;

[Table("movie_company")]
public class MovieProductionCompany
{
    [Column("movie_id")]
    public long MovieId { get; set; }  
    public Movie Movie { get; set; }

    [Column("company_id")]
    public long CompanyId { get; set; } 
    public ProductionCompany ProductionCompany { get; set; }
}