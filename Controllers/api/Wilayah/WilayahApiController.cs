using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Repositories;
using System.Linq.Dynamic.Core;

namespace UjiLab.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class WilayahApiController : ControllerBase
{
    private readonly IWilayah repo;

    public WilayahApiController(IWilayah repo) { this.repo = repo; }

#nullable disable
    [HttpPost("/api/wilayah/provinsi")]
    public async Task<IActionResult> ProvinsiTable()
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

        var init = repo.Provinsis;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaProvinsi.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);

    }

    [HttpPost("/api/wilayah/kabupaten")]
    public async Task<IActionResult> KabupatenTable()
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

        var init = repo.Kabupatens.Select(k => new {
            kabupatenID = k.KabupatenID,
            namaKabupaten = k.NamaKabupaten,
            namaProvinsi = k.Provinsi.NamaProvinsi,
            latitude = k.Latitude,
            longitude = k.Longitude
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.namaKabupaten.ToLower().Contains(searchValue.ToLower()) ||
                a.namaProvinsi.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpPost("/api/wilayah/kecamatan")]
    public async Task<IActionResult> KecamatanTable()
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

        var init = repo.Kecamatans.Select(k => new {
            kecamatanID = k.KecamatanID,
            namaKecamatan = k.NamaKecamatan,
            namaKabupaten = k.Kabupaten.NamaKabupaten,
            namaProvinsi = k.Kabupaten.Provinsi.NamaProvinsi,
            latitude = k.Latitude,
            longitude = k.Longitude
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.namaKecamatan.ToLower().Contains(searchValue.ToLower()) ||
                a.namaKabupaten.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpPost("/api/wilayah/kelurahan")]
    public async Task<IActionResult> KelurahanTable()
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

        var init = repo.Kelurahans.Select(k => new {
            kelurahanID = k.KelurahanID,
            namaKelurahan = k.NamaKelurahan,
            namaKecamatan = k.Kecamatan.NamaKecamatan,
            namaKabupaten = k.Kecamatan.Kabupaten.NamaKabupaten,
            namaProvinsi = k.Kecamatan.Kabupaten.Provinsi.NamaProvinsi
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init
                .Where(a => a.namaKelurahan.ToLower()
                .Contains(searchValue.ToLower()) ||
                a.namaKecamatan.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

#nullable enable

    [HttpGet("/api/wilayah/provinsi/search")]
    public async Task<IActionResult> ProvinsiSearch(string? term)
    {
        var data = await repo.Provinsis
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaProvinsi.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.ProvinsiID,
                data = s.NamaProvinsi
            }).Take(10).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/wilayah/kabupaten/search")]
    public async Task<IActionResult> KabupatenSearch(string? term, string provID)
    {
        var data = await repo.Kabupatens
            .Where(k => k.ProvinsiID == provID)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKabupaten.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KabupatenID,
                data = s.NamaKabupaten
            }).Take(10).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/wilayah/kecamatan/search")]
    public async Task<IActionResult> KecamatanSearch(string? term, string kab)
    {
        var data = await repo.Kecamatans
            .Where(k => k.KabupatenID == kab)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKecamatan.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KecamatanID,
                data = s.NamaKecamatan
            }).Take(10).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/wilayah/kelurahan/search")]
    public async Task<IActionResult> KelurahanSearch(string? term, string kec)
    {
        var data = await repo.Kelurahans
            .Where(k => k.KecamatanID == kec)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaKelurahan.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.KelurahanID,
                data = s.NamaKelurahan
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}
