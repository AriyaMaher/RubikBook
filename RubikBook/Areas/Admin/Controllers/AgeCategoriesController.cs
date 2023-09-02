using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Database.Models;

namespace RubikBook.Areas.Admin.Controllers;

[Area("Admin")]
public class AgeCategoriesController : Controller
{
    IAgeCategory _ageCategory;
    public AgeCategoriesController(IAgeCategory ageCategory)
    {
        _ageCategory = ageCategory;
    }

    public async Task<IActionResult> Index()
    {
        var ageCategories = await _ageCategory.GetAgeCategories();
        return View(ageCategories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AgeCategory ageCategory)
    {

            if (await _ageCategory.AddAgeCate(ageCategory))
            {
                return RedirectToAction(nameof(Index));
            }
        ModelState.AddModelError("AgeCategoryName", "خطا در ثبت");
        return View(ageCategory);
    }

	public async Task<IActionResult> Delete(int id)
	{
        var age = await _ageCategory.GetAgeCategory(id);
        if (age == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return PartialView(age);
	}


	[HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(AgeCategory ageCategory)
    {
        await _ageCategory.DeleteAge(ageCategory.Id);
        return RedirectToAction(nameof(Index));
    }
}
