using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using UjiLab.Models;
using UjiLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UjiLab.Helpers;

namespace UjiLab.Controllers;

public class ParameterController : Controller
{
    private readonly IParameter repo;

    public ParameterController(IParameter repo) => this.repo = repo;

    [HttpGet("/master/parameter")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public IActionResult Index()
    {        
        return View("~/Views/Master/Parameter/Index.cshtml");
    }

    [Authorize(Roles = "SysAdmin, LabAdmin")]
    [HttpGet("/master/parameter/create")]
    public async Task<IActionResult> Create()
    {
        return PartialView("~/Views/Master/Parameter/AddEdit.cshtml", new ParameterVM
        {
            Parameter = new Parameter(),
            JenisParameters = await repo.JenisParameters.ToListAsync()
        });
    }

    [Authorize(Roles = "SysAdmin, LabAdmin")]
    [HttpGet("/master/parameter/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        Parameter? param = await repo.Parameters.FirstOrDefaultAsync(x => x.ParameterID == id);

        if (param is not null)
        {
            return PartialView("~/Views/Master/Parameter/AddEdit.cshtml", new ParameterVM
            {
                Parameter = param,
                JenisParameters = await repo.JenisParameters.ToListAsync()
            });
        }

        return NotFound();
    }

    [HttpPost("/master/parameter/store")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public async Task<IActionResult> Store(ParameterVM model)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(model.Parameter);

            return Json(Result.Success());
        }

        model.JenisParameters = await repo.JenisParameters.ToListAsync();
        return PartialView("~/Views/Master/Parameter/AddEdit.cshtml", model);
    }
}
