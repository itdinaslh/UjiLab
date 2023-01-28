using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using System.Security.Claims;
using UjiLab.Helpers;
using UjiLab.Models;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

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

    [Authorize(Roles = "LabClient")]
    [HttpPost("/clients/store")]
    public async Task<IActionResult> CreateClient(RegistrationVM reg)
    {
        string? uid = ((ClaimsIdentity)User.Identity!).Claims.Where(c => c.Type == "sub").Select(c => c.Value).SingleOrDefault();
        string wwwPath = Uploads.Path;

        string path = Path.Combine(wwwPath, @"clients/" + uid);
        string thumbImg = path + @"/thumbnail";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string extKtp = Path.GetExtension(reg.KTP.FileName);
        string fileNameKTP = GenerateRandomString() + extKtp;
        string extSurat = Path.GetExtension(reg.SuratKuasa.FileName);
        string fileNameSurat = GenerateRandomString() + extSurat;

        reg.Client.RealKtpPath = "/clients/" + uid + "/" + fileNameKTP;

        if (!extKtp.Contains("pdf"))
            reg.Client.KtpPath = "/clients/" + uid + "/thumbnails/" + fileNameKTP;
        else
            reg.Client.KtpPath = "/img/pdf.jpg";

        reg.Client.RealSuratKuasaPath = "/clients/" + uid + "/" + fileNameSurat;

        if (!extSurat.Contains("pdf"))
            reg.Client.SuratKuasaPath = "/clients/" + uid + "/thumbnails/" + fileNameSurat;
        else
            reg.Client.SuratKuasaPath = "/img/pdf.jpg";

        // Upload KTP File First
        using (FileStream stream = new(Path.Combine(path, fileNameKTP), FileMode.Create))
        {
            reg.KTP.CopyTo(stream);
        }

        // Upload Surat Kuasa
        using (FileStream stream = new(Path.Combine(path, fileNameSurat), FileMode.Create))
        {
            reg.SuratKuasa.CopyTo(stream);
        }

        // save thumbnail KTP
        if (!extKtp.Contains("pdf"))
        {
            if (!Directory.Exists(thumbImg))
            {
                Directory.CreateDirectory(thumbImg);
            }

            Image image = Image.Load(reg.KTP.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(thumbImg + "/" + fileNameKTP);
        }

        // save thumbnail Surat Kuasa
        if (!extSurat.Contains("pdf"))
        {
            if (!Directory.Exists(thumbImg))
            {
                Directory.CreateDirectory(thumbImg);
            }

            Image image = Image.Load(reg.SuratKuasa.OpenReadStream());
            image.Mutate(x => x.Resize(600, 400));

            image.Save(thumbImg + "/" + fileNameSurat);
        }

        if (reg.Izin is not null)
        {
            string extIzin = Path.GetExtension(reg.KTP.FileName);
            string fileNameIzin = GenerateRandomString() + extIzin;

            reg.Client.RealDokumenIzinPath = "/clients/" + uid + "/" + fileNameIzin;

            if (!extIzin.Contains("pdf"))
                reg.Client.DokumenIzinPath = "/clients/" + uid + "/thumbnails/" + fileNameIzin;
            else
                reg.Client.DokumenIzinPath = "/img/pdf.jpg";

            // Upload dokumen izin
            using (FileStream stream = new(Path.Combine(path, fileNameIzin), FileMode.Create))
            {
                reg.Izin.CopyTo(stream);
            }

            // save thumbnail dokumen izin
            if (!extIzin.Contains("pdf"))
            {
                if (!Directory.Exists(thumbImg))
                {
                    Directory.CreateDirectory(thumbImg);
                }

                Image image = Image.Load(reg.Izin.OpenReadStream());
                image.Mutate(x => x.Resize(600, 400));

                image.Save(thumbImg + "/" + fileNameIzin);
            }
        }

        reg.Client.ClientID = Guid.Parse(uid!);
        reg.Client.UserID = Guid.Parse(uid!);
        reg.Client.Email = ((ClaimsIdentity)User.Identity!).Claims.Where(c => c.Type == "email").Select(c => c.Value).SingleOrDefault();
        reg.Client.IsVerified = false;
        reg.Client.StatusID = 1;

        if (ModelState.IsValid)
        {
            await clientRepo.StoreDataAsync(reg.Client);

            return RedirectToAction("Dashboard", "Home");
        }

        

        return View("~/Views/Registration/Index.cshtml", reg);
    }

    private static string GenerateRandomString()
    {
        int length = 40;

        StringBuilder builder = new();

        Random random = new();

        char letter;

        for (int i = 0; i < length; i++)
        {
            double flt = random.NextDouble();
            int shift = Convert.ToInt32(Math.Floor(25 * flt));
            letter = Convert.ToChar(shift + 65);
            builder.Append(letter);
        }

        return builder.ToString();
    }
}