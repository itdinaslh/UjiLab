using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using UjiLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UjiLab.Helpers;

namespace UjiLab.Controllers;

public class MetodeParameterController : Controller
{
    private readonly IParameter repo;

    public MetodeParameterController(IParameter repo) => this.repo = repo;

    [Authorize(Roles = "SysAdmin, LabAdmin")]
    [HttpGet("/master/metode-parameter")]
    public IActionResult Index()
    {
        return View("~/Views/Master/MetodeParameter/Index.cshtml");
    }

    [HttpGet("/master/metode-parameter/create")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/MetodeParameter/AddEdit.cshtml", new MetodeParameter());
    }

    [HttpGet("/master/metode-parameter/edit")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public async Task<IActionResult> Edit(int id)
    {
        MetodeParameter? data = await repo.MetodeParameters.FirstOrDefaultAsync(x => x.MetodeParameterID == id);

        if (data is not null)
        {
            return PartialView("~/Views/Master/MetodeParameter/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/metode-parameter/store")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public async Task<IActionResult> Store(MetodeParameter model)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveMetodeAsync(model);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/MetodeParameter/AddEdit.cshtml", model);
    }
}
