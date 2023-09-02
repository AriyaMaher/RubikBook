using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Database.Models;

namespace RubikBook.Areas.Admin.Controllers;

[Area("Admin")]
public class GroupsController : Controller
{
    IGroup _group;
    public GroupsController(IGroup group)
    {
        _group = group;
    }

    public async Task<IActionResult> Index()
    {
        var groups = await _group.GetGroups();
        return View(groups);
    }

    public async Task<IActionResult> Details(int id)
    {
        var group = await _group.GetGroup(id);
        if (group != null)
        {
            return View(group);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var group = await _group.GetGroup(id);
        if (group != null)
        {
            return View(group);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Group group)
    {
        if (ModelState.IsValid)
        {
            var result = await _group.EditGroup(group);
            return RedirectToAction("Details", new { id = group.Id });
        }
        return View(group);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Group group)
    {
        if (ModelState.IsValid)
        {
            if (await _group.AddGroup(group))
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("GroupName", "خطا در ثبت گروه جدید");
            return View(group);
        }
        return View(group);
    }


    public async Task<IActionResult> Delete(int id)
    {
        var group = await _group.GetGroup(id);
        if (group == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return PartialView(group);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Group group)
    {
        await _group.DeleteGroup(group.Id);
        return RedirectToAction(nameof(Index));
    }
}
