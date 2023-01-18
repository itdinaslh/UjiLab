using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Helpers;

namespace UjiLab.Controllers;

public class LayananController : Controller
{
    private readonly ILayanan repo;

    public LayananController(ILayanan repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/layanan")]
    public IActionResult Index()
    {
        return View("~/Views/Master/Layanan/Index.cshtml");
    }

    [HttpGet("/master/layanan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/Layanan/AddEdit.cshtml", new Layanan());
    }

    [HttpGet("/master/layanan/edit")]
    public async Task<IActionResult> Edit(int layananID)
    {
        Layanan? data = await repo.Layanans.FirstOrDefaultAsync(l => l.LayananID == layananID);

        if (data is not null)
        {
            return PartialView("~/Views/Master/Layanan/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/layanan/store")]
    public async Task<IActionResult> Store(Layanan layanan)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(layanan);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/Layanan/AddEdit.cshtml", layanan);
    }
}
