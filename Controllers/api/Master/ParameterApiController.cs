using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Text;
using UjiLab.Domain.Entities;
using System.Web;

namespace UjiLab.Controllers.api.Master;

[Route("api/[controller]")]
[ApiController]
public class ParameterApiController : ControllerBase
{
    private readonly IParameter repo;

    public ParameterApiController(IParameter repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/master/parameter")]
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

        var init = repo.Parameters.Select(x => new {
            parameterID = x.ParameterID,
            namaParameter = x.NamaParameter,
            satuan = x.Satuan,
            biayaAlat = x.BiayaAlat == null || x.BiayaAlat == 0 ? "0" : x.BiayaAlat!.Value.ToString("#,###"),
            biayaUji = x.BiayaUji == null || x.BiayaUji == 0 ? "0" : x.BiayaUji!.Value.ToString("#,###"),
            namaJenis = x.JenisParameter.NamaJenis
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.namaParameter.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpPost("/api/master/metode-parameter")]
    [Authorize]
    public async Task<IActionResult> MetodeParameterTable()
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

        var init = repo.MetodeParameters;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaMetode!.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/jenis-parameter/search")]
    public async Task<IActionResult> Search(string? term)
    {
        var data = await repo.JenisParameters
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaJenis.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.JenisParameterID,
                data = s.NamaJenis
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/metode-parameter/search")]
    public async Task<IActionResult> SearchMetode(string? term)
    {
        var data = await repo.MetodeParameters
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaMetode.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.MetodeParameterID,
                data = s.NamaMetode
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/parameter/search")]
    public async Task<IActionResult> SearchParameter(string? term)
    {
        var data = await repo.Parameters
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaParameter.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.ParameterID,
                data = HttpUtility.HtmlDecode(s.NamaParameter)
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/parameter/getpricebyid")]
    public async Task<IActionResult> GetPriceFromID(int id)
    {
        Parameter? param = await repo.Parameters.FirstOrDefaultAsync(x => x.ParameterID == id);

        if (param is not null)
        {
            var data = new
            {
                biayaUji = param.BiayaUji,
                biayaAlat = param.BiayaAlat
            };

            return Ok(data);
        }

        return NotFound();
    }

    private static string ActualText(string str)
    {
        // Create two different encodings.
        Encoding ascii = Encoding.ASCII;
        Encoding unicode = Encoding.Unicode;

        // Convert the string into a byte array.
        byte[] unicodeBytes = unicode.GetBytes(str);

        // Perform the conversion from one encoding to the other.
        byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

        // Convert the new byte[] into a char[] and then into a string.
        char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
        ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
        string asciiString = new string(asciiChars);

        return asciiString;
    }
}
