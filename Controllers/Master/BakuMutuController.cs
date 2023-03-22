using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

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
        return PartialView("~/Views/Master/BakuMutu/AddEdit.cshtml", new BakuMutu());
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
}
