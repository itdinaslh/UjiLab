using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Repositories;

namespace UjiLab.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class TipeLokasiApiController : ControllerBase
{
    private readonly ITipeLokasi repo;

    public TipeLokasiApiController(ITipeLokasi repo) => this.repo = repo;

    [HttpGet("/api/master/tipe-lokasi/search")]
    public async Task<IActionResult> SearchTipeLokasi(string? term)
    {
        var data = await repo.TipeLokasis
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaTipe.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.TipeLokasiID,
                data = s.NamaTipe
            }).ToListAsync();

        return Ok(data);
    }
}
