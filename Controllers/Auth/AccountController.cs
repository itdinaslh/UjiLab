using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace UjiLab.Controllers;

public class AccountController : Controller
{
    [Route("/account/denied")]
    public IActionResult Denied()
    {
        return View();
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        string myReturn = Simpanan.AuthServer + HttpUtility.UrlEncode(Simpanan.ReturnUrl);
        return Redirect(myReturn);
    }
}
