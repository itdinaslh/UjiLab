using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UjiLab.Controllers
{
    public class PengujianController : Controller
    {
        [Authorize(Roles = "SysAdmin")]
        [HttpGet("/pengujian/list")]
        public IActionResult List()
        {
            return View();
        }
        [Authorize(Roles = "SysAdmin")]
        [HttpGet("/pengujian/review_teknis")]
        public IActionResult ReviewTeknis()
        {
            return View();
        }
    }
}
