using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using UjiLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UjiLab.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace UjiLab.Controllers;

public class BidangUsahaController : Controller
{
    private readonly IBidangUsaha repo;

    public BidangUsahaController(IBidangUsaha repo)
    {
        this.repo = repo;
    }

    [Authorize]
    [HttpGet("/master/bidang-usaha")]
    public IActionResult Index()
    {
        return View("~/Views/Master/BidangUsaha/Index.cshtml");
    }

    [HttpGet("/master/bidang-usaha/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/BidangUsaha/AddEdit.cshtml", new BidangUsaha());
    }

    [HttpGet("/master/bidang-usaha/edit")]
    public async Task<IActionResult> Edit(int bidangUsahaID)
    {
        BidangUsaha? data = await repo.BidangUsahas.FirstOrDefaultAsync(b => b.BidangUsahaID == bidangUsahaID);

        if (data is not null)
        {
            return PartialView("~/Views/Master/BidangUsaha/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/bidang-usaha/store")]
    public async Task<IActionResult> Store(BidangUsaha usaha)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(usaha);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/BidangUsaha/AddEdit.cshtml", usaha);
    }
}
