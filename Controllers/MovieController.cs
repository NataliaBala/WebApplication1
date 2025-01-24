using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zaliczenie.Data;
using Zaliczenie.Models;

namespace Zaliczenie.Controllers;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private const int DefaultPageSize = 10;

    public MoviesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string searchString)
    {
        ViewData["CurrentSort"] = sortOrder;
        ViewData["TitleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
        ViewData["DateSortParam"] = sortOrder == "date" ? "date_desc" : "date";
        ViewData["CurrentFilter"] = searchString;

        var movieQuery = _dbContext.Movies
            .Include(m => m.MovieProductionCompanies)
                .ThenInclude(mpc => mpc.ProductionCompany)
            .Include(m => m.MovieKeywords)
                .ThenInclude(mk => mk.Keyword)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            movieQuery = movieQuery.Where(m => m.Title.Contains(searchString));
        }

        movieQuery = sortOrder switch
        {
            "title_desc" => movieQuery.OrderByDescending(m => m.Title),
            "date" => movieQuery.OrderBy(m => m.ReleaseDate),
            "date_desc" => movieQuery.OrderByDescending(m => m.ReleaseDate),
            _ => movieQuery.OrderBy(m => m.Title)
        };

        var paginatedMovies = await PaginatedList<Movie>.CreateAsync(movieQuery, pageNumber ?? 1, DefaultPageSize);
        return View(paginatedMovies);
    }

    public async Task<IActionResult> Details(long id)
    {
        var movieDetails = await _dbContext.Movies
            .Include(m => m.MovieProductionCompanies)
                .ThenInclude(mpc => mpc.ProductionCompany)
            .Include(m => m.MovieKeywords)
                .ThenInclude(mk => mk.Keyword)
            .FirstOrDefaultAsync(m => m.MovieId == id);

        return movieDetails == null ? NotFound() : View(movieDetails);
    }

    public async Task<IActionResult> ManageKeywords(long id)
    {
        var movieWithKeywords = await _dbContext.Movies
            .Include(m => m.MovieKeywords)
                .ThenInclude(mk => mk.Keyword)
            .Include(m => m.MovieProductionCompanies)
            .FirstOrDefaultAsync(m => m.MovieId == id);

        return movieWithKeywords == null ? NotFound() : View(movieWithKeywords);
    }

    [HttpPost]
    public async Task<IActionResult> AddKeyword(long movieId, string keywordName)
    {
        if (string.IsNullOrWhiteSpace(keywordName))
        {
            return BadRequest("Keyword cannot be empty.");
        }

        var targetMovie = await _dbContext.Movies
            .Include(m => m.MovieKeywords)
                .ThenInclude(mk => mk.Keyword)
            .FirstOrDefaultAsync(m => m.MovieId == movieId);

        if (targetMovie == null)
        {
            return NotFound("Movie not found.");
        }

        var existingKeyword = await _dbContext.Keywords
            .FirstOrDefaultAsync(k => k.KeywordName.ToLower() == keywordName.ToLower())
            ?? new Keyword { KeywordName = keywordName };

        if (existingKeyword.KeywordId == 0)
        {
            _dbContext.Keywords.Add(existingKeyword);
            await _dbContext.SaveChangesAsync();
        }

        if (!targetMovie.MovieKeywords.Any(mk => mk.KeywordId == existingKeyword.KeywordId))
        {
            targetMovie.MovieKeywords.Add(new MovieKeyword
            {
                MovieId = targetMovie.MovieId,
                KeywordId = existingKeyword.KeywordId
            });
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ManageKeywords), new { id = movieId });
    }

    [HttpPost]
    public async Task<IActionResult> RemoveKeyword(long movieId, long keywordId)
    {
        var keywordAssociation = await _dbContext.MovieKeywords
            .FirstOrDefaultAsync(mk => mk.MovieId == movieId && mk.KeywordId == keywordId);

        if (keywordAssociation != null)
        {
            _dbContext.MovieKeywords.Remove(keywordAssociation);
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToAction(nameof(ManageKeywords), new { id = movieId });
    }
}