using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Database.Models;

namespace RubikBook.Areas.Admin.Controllers;

[Area("Admin")]
public class PublishersController : Controller
{
    IPublisher _publisher;
    public PublishersController(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task<IActionResult> Index()
    {
        var publishers = await _publisher.GetPublishers();
        return View(publishers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Publisher publisher)
    {
        if (ModelState.IsValid)
        {
            if (await _publisher.AddPublisher(publisher))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }
        return View(publisher);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var publisher = await _publisher.GetPublisher(id);
        if (publisher==null)
        {
            return RedirectToAction(nameof(Index));
        }
        return PartialView(publisher);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Publisher publisher)
    {
        await _publisher.DeletePublisher(publisher.Id);
        return RedirectToAction(nameof(Index));
    }
}
