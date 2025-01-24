using System.ComponentModel.DataAnnotations.Schema;

namespace Zaliczenie.Models;

[Table("production_company")]
public class ProductionCompany
{
    [Column("company_id")]
    public long CompanyId { get; set; } 
    
    [Column("company_name")]
    public string CompanyName { get; set; }

    public ICollection<MovieProductionCompany> MovieProductionCompanies { get; set; }
}