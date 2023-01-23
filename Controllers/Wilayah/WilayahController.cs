using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UjiLab.Controllers;

public class WilayahController : Controller
{
    [HttpGet("/master/wilayah/provinsi")]
    [Authorize]
    public IActionResult Provinsi()
    {
        return View("~/Views/Wilayah/Provinsi.cshtml");
    }

    [HttpGet("/master/wilayah/kabupaten")]
    [Authorize]
    public IActionResult Kabupaten()
    {
        return View("~/Views/Wilayah/Kabupaten.cshtml");
    }

    [Authorize]
    [HttpGet("/master/wilayah/kecamatan")]
    public IActionResult Kecamatan()
    {
        return View("~/Views/Wilayah/Kecamatan.cshtml");
    }

    [Authorize]
    [HttpGet("/master/wilayah/kelurahan")]
    public IActionResult Kelurahan()
    {
        return View("~/Views/Wilayah/Kelurahan.cshtml");
    }
}
