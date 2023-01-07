using Microsoft.AspNetCore.Mvc;

namespace UjiLab.Controllers;

public class AccountController : Controller
{
    [Route("/account/denied")]
    public IActionResult Denied()
    {
        return View();
    }
}
