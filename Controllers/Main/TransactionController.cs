using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UjiLab.Controllers;

public class TransactionController : Controller
{
    [Authorize(Roles = "LabClient")]
    [HttpGet("/transaction/clients/list")]
    public IActionResult ClientIndex()
    {
        return View();
    }
}
