using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UjiLab.Controllers;

public class ClientController : Controller
{
    [HttpGet("/clients/list")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public IActionResult List()
    {
        return View();
    }
}
