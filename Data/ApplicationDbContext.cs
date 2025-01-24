using Microsoft.EntityFrameworkCore;
using Zaliczenie.Models;

namespace Zaliczenie.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<ProductionCompany> ProductionCompanies { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieKeyword> MovieKeywords { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    
    public DbSet<MovieProductionCompany> MovieProductionCompanies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Keyword>().ToTable("keyword");
        modelBuilder.Entity<Keyword>().HasKey(k => k.KeywordId);
        modelBuilder.Entity<Movie>().ToTable("movie");
        modelBuilder.Entity<Movie>().HasKey(m => m.MovieId);
        modelBuilder.Entity<ProductionCompany>().ToTable("production_company");
        modelBuilder.Entity<ProductionCompany>().HasKey(pc => pc.CompanyId);
        modelBuilder.Entity<MovieProductionCompany>().HasKey(mpc => new { mpc.MovieId, mpc.CompanyId });
        modelBuilder.Entity<MovieProductionCompany>().HasOne(mpc => mpc.Movie).WithMany(m => m.MovieProductionCompanies).HasForeignKey(mpc => mpc.MovieId);
        modelBuilder.Entity<MovieProductionCompany>().HasOne(mpc => mpc.ProductionCompany).WithMany(pc => pc.MovieProductionCompanies).HasForeignKey(mpc => mpc.CompanyId);
        modelBuilder.Entity<MovieKeyword>().HasKey(mk => new { mk.MovieId, mk.KeywordId });
        modelBuilder.Entity<MovieKeyword>().HasOne(mk => mk.Movie).WithMany(m => m.MovieKeywords).HasForeignKey(mk => mk.MovieId);
        modelBuilder.Entity<MovieKeyword>().HasOne(mk => mk.Keyword).WithMany(k => k.MovieKeywords).HasForeignKey(mk => mk.KeywordId);
        
    }
}