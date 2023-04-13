using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace UjiLab.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class PengajuanApiController : ControllerBase
{
    private readonly ITipePengajuan repo;
    private readonly IJenisPengajuan jRepo;

    public PengajuanApiController(ITipePengajuan repo, IJenisPengajuan jRepo) { this.repo = repo; this.jRepo = jRepo; }

    [HttpPost("/api/master/pengajuan/tipe")]
    public async Task<IActionResult> TipeDataTable()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = repo.TipePengajuans.Select(x => new
        {
            tipePengajuanID = x.TipePengajuanID,
            namaTipe = x.NamaTipe,
            namaJenis = x.JenisPengajuan.NamaJenis
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.namaTipe.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

#nullable enable

    [HttpGet("/api/master/pengajuan/tipe/search")]
    public async Task<IActionResult> SearchTipe(string? term)
    {
        var data = await repo.TipePengajuans            
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaTipe.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.TipePengajuanID,
                data = s.NamaTipe
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/pengajuan/tipe/searchbyjenis")]
    public async Task<IActionResult> SearchTipeByJenis(int jenis, string? term)
    {
        var data = await repo.TipePengajuans
            .Where(j => j.JenisPengajuanID == jenis)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaTipe.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.TipePengajuanID,
                data = s.NamaTipe
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/pengajuan/jenis/search")]
    public async Task<IActionResult> SearchJenis(int jenis, string? term)
    {
        var data = await jRepo.JenisPengajuans            
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaJenis.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.JenisPengajuanID,
                data = s.NamaJenis
            }).ToListAsync();

        return Ok(data);
    }
}
