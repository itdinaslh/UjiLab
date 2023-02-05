using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using UjiLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UjiLab.Helpers;

namespace UjiLab.Controllers;

[Authorize(Roles = "SysAdmin, LabAdmin")]
public class OutputHasilController : Controller
{
    private readonly IOutputHasil repo;

    public OutputHasilController(IOutputHasil repo) { this.repo = repo; }

    [HttpGet("/master/output-hasil")]
    public IActionResult Index()
    {
        return View("~/Views/Master/OutputHasil/Index.cshtml");
    }

    [HttpGet("~/master/output-hasil/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/OutputHasil/AddEdit.cshtml", new OutputHasil());
    }

    [HttpGet("/master/output-hasil/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        OutputHasil? data = await repo.OutputHasils.FirstOrDefaultAsync(x => x.OutputHasilID== id);

        if (data is not null)
            return PartialView("~/Views/Master/OutputHasil/AddEdit.cshtml", data);

        return NotFound();
    }

    [HttpPost("/master/output-hasil/store")]
    public async Task<IActionResult> Store(OutputHasil model)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(model);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/OutputHasil/AddEdit.cshtml", model);
    }
}
