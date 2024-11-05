using WebApplication1.Models;
using WebApplication1.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    //Lista kontaktów
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }
    [HttpGet]
    //Formularz dodania kontaktu
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    //Odebranie i zapisanie nowego kontaktu
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        _contactService.Add(model);
        return RedirectToAction(nameof(Index));

    }
    public ActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }
    [HttpGet]
    public ActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }
    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(model);
        return RedirectToAction(nameof(System.Index));

    }
    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return View(nameof(System.Index));
    }
    
}