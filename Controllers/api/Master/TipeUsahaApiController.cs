using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UjiLab.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class TipeUsahaApiController : ControllerBase
{
    private readonly ITipeUsaha tipeRepo;

    public TipeUsahaApiController(ITipeUsaha tipeRepo) { this.tipeRepo = tipeRepo; }

    [HttpGet("/api/master/tipe-usaha/search")]
    public async Task<IActionResult> Search(string? term)
    {
        var data = await tipeRepo.TipeUsahas
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaTipe.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.TipeUsahaID,
                data = s.NamaTipe
            }).ToListAsync();

        return Ok(data);
    }
}
