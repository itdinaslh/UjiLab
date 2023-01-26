using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Models;

namespace UjiLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClient clientRepo;

        public HomeController(ILogger<HomeController> logger, IClient thisClient)
        {
            _logger = logger;
            clientRepo = thisClient;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "SysAdmin, LabClient")]
        [HttpGet("/dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            if (User.IsInRole("LabClient"))
            {
                // Check if user already in client
                Client? client = await clientRepo.Clients.Where(c => c.Email == User.Identity!.Name).FirstOrDefaultAsync();

                if (client == null)
                {
                    return RedirectToAction("Index", "Registration");
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}