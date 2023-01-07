using Microsoft.AspNetCore.Mvc;

namespace UjiLab.Controllers;

public class WilayahController : Controller
{
    [HttpGet("/master/wilayah/provinsi")]
    public IActionResult Provinsi()
    {
        return View("~/Views/Wilayah/Provinsi.cshtml");
    }

    [HttpGet("/master/wilayah/kabupaten")]
    public IActionResult Kabupaten()
    {
        return View("~/Views/Wilayah/Kabupaten.cshtml");
    }

    [HttpGet("/master/wilayah/kecamatan")]
    public IActionResult Kecamatan()
    {
        return View("~/Views/Wilayah/Kecamatan.cshtml");
    }

    [HttpGet("/master/wilayah/kelurahan")]
    public IActionResult Kelurahan()
    {
        return View("~/Views/Wilayah/Kelurahan.cshtml");
    }
}
