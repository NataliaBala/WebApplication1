using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class CalculatorController : Controller
{
    // GET
    /*public IActionResult Result(Operator? op, double? a, double? b)
    {
        if (a == null || b == null)
        {
            ViewBag.ErrorMessage = "Zły format a lub b";
            return View("CustomError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Zły operator";
            return View("CustomError");
        }


        ViewBag.a = a;
        ViewBag.b = b;
        switch (op)
        {
            case Operator.Add:
                ViewBag.result = a + b;
                ViewBag.op = "+";
                break;
            case Operator.Sub:
                ViewBag.result = a - b;
                ViewBag.op = "-";
                break;
            case Operator.Mult:
                ViewBag.result = a * b;
                ViewBag.op = "*";
                break;
            case Operator.Div:
                ViewBag.result = a / b;
                ViewBag.op = "/";
                break;

        }
        return View();
    }
    public enum Operator
    {
        Add, Sub, Mult, Div
    }*/
    
    
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
    public IActionResult Form()
    {
        return View();
    }
}