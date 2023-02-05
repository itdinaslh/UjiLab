using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Helpers;

namespace UjiLab.Controllers;

[Authorize(Roles = "SysAdmin, LabAdmin")]
public class PengajuanController : Controller
{
    private readonly ITipePengajuan repo;

    public PengajuanController(ITipePengajuan repo) { this.repo = repo; }

    [HttpGet("/master/pegajuan/tipe")]
    public IActionResult Tipe()
    {
        return View("~/Views/Master/Pengajuan/Tipe/Index.cshtml");
    }

    [HttpGet("/master/pengajuan/tipe/create")]
    public IActionResult AddTipe()
    {
        return PartialView("~/Views/Master/Pengajuan/Tipe/AddEdit.cshtml", new TipePengajuan());
    }

    [HttpGet("~/master/pengajuan/tipe/edit")]
    public async Task<IActionResult> EditTipe(int id)
    {
        TipePengajuan? data = await repo.TipePengajuans.FirstOrDefaultAsync(x => x.TipePengajuanID == id);

        if (data is not null)
            return PartialView("~/Views/Master/Pengajuan/Tipe/AddEdit.cshtml", data);

        return NotFound();
    }

    [HttpPost("~/master/pengajuan/tipe/store")]
    public async Task<IActionResult> StoreTipe(TipePengajuan tipe)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(tipe);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/Pengajuan/Tipe/AddEdit.cshtml", tipe);
    }
}
