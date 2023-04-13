using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace UjiLab.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class OutputHasilApiController : ControllerBase
{
    private readonly IOutputHasil repo;
    
    public OutputHasilApiController(IOutputHasil repo) { this.repo = repo; }

    [HttpPost("/api/master/output-hasil")]
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

        var init = repo.OutputHasils.Select(x => new
        {
            outputHasilID = x.OutputHasilID,
            outputName = x.OutputName,
            kode = x.Kode,
            namaTipe = x.TipePengajuan.NamaTipe
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.outputName.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/output-hasil/searchbytipe")]
    public async Task<IActionResult> SearchOutputByTipe(int tipe, string? term)
    {
        var data = await repo.OutputHasils
            .Where(j => j.TipePengajuanID == tipe)
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.OutputName.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.OutputHasilID,
                data = s.Kode + " - " + s.OutputName
            }).ToListAsync();

        return Ok(data);
    }

    [HttpGet("/api/master/output-hasil/search")]
    public async Task<IActionResult> Search(string? term)
    {
        var data = await repo.OutputHasils            
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.OutputName.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.OutputHasilID,
                data = s.Kode + " - " + s.OutputName
            }).ToListAsync();

        return Ok(data);
    }
}
