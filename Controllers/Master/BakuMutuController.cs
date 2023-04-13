using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Helpers;
using UjiLab.Models;

namespace UjiLab.Controllers;

public class BakuMutuController : Controller
{
    private readonly IBakuMutu repo;

    public BakuMutuController(IBakuMutu repo) => this.repo = repo;

    [Authorize]
    [HttpGet("/master/baku-mutu")]
    public IActionResult Index()
    {
        return View("~/Views/Master/BakuMutu/Index.cshtml");
    }

    [Authorize]
    [HttpGet("/master/baku-mutu/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/BakuMutu/AddEdit.cshtml", new BakuMutuVM());
    }

    [Authorize]
    [HttpGet("/master/baku-mutu/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        BakuMutu? data = await repo.BakuMutus.FirstOrDefaultAsync(x => x.BakuMutuID == id);

        if (data is not null) {
            return PartialView("~/Views/Master/BakuMutu/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/baku-mutu/store")]
    public async Task<IActionResult> StoreBakuMutu(BakuMutuVM model)
    {
        if (ModelState.IsValid)
        {
            model.BakuMutu.UpdatedBy = User.Identity!.Name;
            await repo.SaveBakuMutuAsync(model.BakuMutu);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/BakuMutu/AddEdit.cshtml", model);
    }

    [Authorize(Roles = "SysAdmin, LabAdmin")]
    [HttpGet("/master/baku-mutu/jenis")]
    public IActionResult Jenis()
    {
        return View("~/Views/Master/JenisBakuMutu/Index.cshtml");
    }

    [Authorize(Roles = "SysAdmin, LabAdmin")]
    [HttpGet("/master/baku-mutu/jenis/create")]
    public IActionResult CreateJenis()
    {
        return PartialView("~/Views/Master/JenisBakuMutu/AddEdit.cshtml", new JenisBakuMutu());
    }

    [Authorize(Roles = "SysAdmin, LabAdmin")]
    [HttpGet("/master/baku-mutu/jenis/edit")]
    public async Task<IActionResult> EditJenis(int id)
    {
        JenisBakuMutu? data = await repo.JenisBakuMutus.FirstOrDefaultAsync(x => x.JenisBakuMutuID == id);

        if (data is not null)
        {
            return PartialView("~/Views/Master/JenisBakuMutu/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [Authorize(Roles = "SysAdmin, LabAdmin")]
    [HttpPost("/master/baku-mutu/jenis/store")]
    public async Task<IActionResult> StoreJenis(JenisBakuMutu model)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveJenisAsync(model);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/JenisBakuMutu/AddEdit.cshtml", model);
    }
}
