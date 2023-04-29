using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace UjiLab.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class BakuMutuApiController : ControllerBase
{
    private readonly IBakuMutu repo;

    public BakuMutuApiController(IBakuMutu repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/master/baku-mutu")]
    [Authorize]
    public async Task<IActionResult> DataTable()
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

        var init = repo.BakuMutus.Select(x => new {
            bakuMutuID = x.BakuMutuID,
            jenisPengajuan = x.OutputHasil.TipePengajuan.JenisPengajuan.NamaJenis,
            tipePengajuan = x.OutputHasil.TipePengajuan.NamaTipe,
            outputHasil = x.OutputHasil.Kode + " - " + x.OutputHasil.OutputName,
            metodeParameter = x.MetodeParameter!.NamaMetode,
            jenisBakuMutu = x.JenisBakuMutu!.NamaJenis,
            parameter = x.Parameter.NamaParameter,
            biayaUji = x.BiayaUji == 0 ? "0" : x.BiayaUji.ToString("#,###"),
            biayaAlat = x.BiayaAlat == 0 ? "0" :  x.BiayaAlat.ToString("#,###")
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.jenisBakuMutu.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpPost("/api/master/baku-mutu/jenis")]
    [Authorize]
    public async Task<IActionResult> JenisBakuMutuTable()
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

        var init = repo.JenisBakuMutus;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaJenis.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/baku-mutu/jenis/search")]
    public async Task<IActionResult> SearchJenis(string? term, int outputID)
    {
        var baku = await repo.BakuMutus
            .Where(x => x.OutputHasilID == outputID)
            .Select(x => x.JenisBakuMutuID).Distinct().ToListAsync();

        var data = await repo.JenisBakuMutus
            .Where(x => baku.Contains(x.JenisBakuMutuID))
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaJenis.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.JenisBakuMutuID,
                data = s.NamaJenis
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/baku-mutu/table-data")]
    public async Task<IActionResult> PopulateBakuMutuData(int jenisID)
    {
        var data = await repo.BakuMutus
            .Where(x => x.JenisBakuMutuID == jenisID)
            .Where(x => x.IsActive == true)
            .Select(x => new
            {
                x.BakuMutuID,
                x.Parameter.NamaParameter,
                satuan = x.Parameter.Satuan ?? "",
                namaMetode = x.MetodeParameter!.NamaMetode ?? "",
                x.BiayaUji,                
                x.BiayaAlat,                
                x.IsActive, 
                selected = true
            })
            .OrderBy(x => x.BakuMutuID)
            .ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/baku-mutu/all-data")]
    public async Task<IActionResult> PopulateAllData()
    {
        var data = await repo.BakuMutus            
            .Where(x => x.IsActive == true)
            .Select(x => new
            {
                x.BakuMutuID,
                x.Parameter.NamaParameter,
                satuan = x.Parameter.Satuan ?? "",
                namaMetode = x.MetodeParameter!.NamaMetode ?? "",
                x.BiayaUji,
                x.BiayaAlat,
                x.IsActive,
                selected = true
            })
            .OrderBy(x => x.BakuMutuID)
            .ToListAsync();

        return Ok(data);
    }
}
