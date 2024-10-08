using System.Diagnostics;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult calculator(Operator? op, double? a, double? b)
    {
        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b!";
            return View("CustomError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CustomError");
        }
        
        
        ViewBag.A = a;
        ViewBag.B = b;
        switch (op)
        {
            case Operator.add:
                ViewBag.Result = a + b;
                break;
            case  Operator.sub:
                ViewBag.Result = a - b;
                break;
            case Operator.div:
                ViewBag.Result = a / b;
                break;
                
                case Operator.nul:
                ViewBag.Result = a * b;
                break;
                

        }
        



        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

 public enum Operator
{
    add, sub, div, nul
}