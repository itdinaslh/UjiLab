using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Helpers;

namespace UjiLab.Controllers;

public class KondisiController : Controller
{
    private readonly IKondisi repo;

    public KondisiController(IKondisi repo) { this.repo = repo; }

    [HttpGet("/master/kondisi")]
    public IActionResult Index()
    {
        return View("~/Views/Master/Kondisi/Index.cshtml");
    }

    [HttpGet("/master/kondisi/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/Kondisi/AddEdit.cshtml", new Kondisi());
    }

    [HttpGet("/master/kondisi/edit")]
    public async Task<IActionResult> Edit(int kondisiID)
    {
        Kondisi? data = await repo.Kondisis.FirstOrDefaultAsync(k => k.KondisiID == kondisiID);

        if (data is not null)
        {
            return PartialView("~/Views/Master/Kondisi/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/kondisi/store")]
    public async Task<IActionResult> Store(Kondisi kondisi)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(kondisi);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/Kondisi/AddEdit.cshtml", kondisi);
    }
}
