using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Database.Models;

namespace RubikBook.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthorsController : Controller
{
    IAuthor _author;
    public AuthorsController(IAuthor author)
    {
        _author = author;
    }

    public async Task<IActionResult> Index()
    {
        var authors = await _author.GetAuthors();
        return View(authors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Author author)
    {
        if (ModelState.IsValid)
        {
            if (await _author.AddAuthor(author)) {
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        return View(author);
    }

    public async Task<IActionResult> Details(int id)
    {
        var author = await _author.GetAuthor(id);
        if (author != null)
        {
            return View(author);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var author = await _author.GetAuthor(id);
        if (author != null)
        {
            return View(author);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(Author author)
	{
        if (ModelState.IsValid)
        {
			await _author.EditAuthor(author);
			return RedirectToAction(nameof(Index));
		}
        return View(author);
	}

    public async Task<IActionResult> Delete(int id)
    {
        var author = await _author.GetAuthor(id);
        if(author == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return PartialView(author);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Author author)
    {
        await _author.DeleteAuthor(author.Id);
        return RedirectToAction(nameof(Index));
    }

}
