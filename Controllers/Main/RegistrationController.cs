using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Helpers;
using UjiLab.Models;

namespace UjiLab.Controllers;

public class RegistrationController : Controller
{
    private readonly IClient clientRepo;

    public RegistrationController(IClient clientRepo) { this.clientRepo = clientRepo; }

    [HttpGet("/clients/registration")]
    [Authorize]
    public IActionResult Index()
    {
        return View(new RegistrationVM
        {
            Client = new Client()
        });
    }

    [HttpPost("/clients/store")]
    public async Task<IActionResult> CreateClient(Client client)
    {
        if (ModelState.IsValid)
        {
            await clientRepo.StoreDataAsync(client);

            return RedirectToAction("Dashboard", "Home");
        }

        return View("~/Views/Registration/Index.cshtml", client);
    }
}