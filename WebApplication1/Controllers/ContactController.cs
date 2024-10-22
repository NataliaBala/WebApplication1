using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()

    {
        {
            1, new ContactModel()
            {

                Id = 1,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "Adam@abecki.com",
                BirthDay = new DateOnly(year: 1999, month: 10, day: 10),
                PhoneNumber = "222-444-555"

            }

        }

    };

    private static int currentId = 3;



    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }

//Fromularz dodania kontaktow
[HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

}