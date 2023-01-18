using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Helpers;

namespace UjiLab.Controllers.Master;

public class MetodeSamplingController : Controller
{

    private readonly IMetodeSampling repo;

    public MetodeSamplingController(IMetodeSampling repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/metode-sampling")]
    public IActionResult Index()
    {
        return View("~/Views/Master/MetodeSampling/Index.cshtml");
    }

    [HttpGet("/master/metode-sampling/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/MetodeSampling/AddEdit.cshtml", new MetodeSampling());
    }

    [HttpGet("/master/metode-sampling/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        MetodeSampling? data = await repo.MetodeSamplings.FirstOrDefaultAsync(x => x.MetodeSamplingID == id);

        if (data is not null)
        {
            return PartialView("~/Views/Master/MetodeSampling/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/metode-sampling/store")]
    public async Task<IActionResult> Store(MetodeSampling metode)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(metode);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/MetodeSampling/AddEdit.cshtml", metode);
    }
}
