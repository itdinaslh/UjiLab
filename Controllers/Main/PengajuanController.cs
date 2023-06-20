using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Models;

namespace UjiLab.Controllers.Main
{
    public class PengajuanController : Controller
    {
        [Authorize(Roles = "SysAdmin")]
        [HttpGet("/pengajuan/list")]
        public IActionResult List()
        {
            return View();
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpGet("/pengajuan/pembayaran")]
        public IActionResult Payment()
        {
            return View();
        }

        [Authorize(Roles = "SysAdmin")]
        [HttpGet("/pengajuan/details")]
        public IActionResult PengajuanDetail()
        {
            return View();
        }
    }
}
