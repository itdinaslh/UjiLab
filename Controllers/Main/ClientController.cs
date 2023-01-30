using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Models;

namespace UjiLab.Controllers;

public class ClientController : Controller
{
    private readonly IClient repo;

    public ClientController(IClient repo) { this.repo = repo; }


    [HttpGet("/clients/list")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public IActionResult List()
    {
        return View();
    }

    [HttpGet("/clients/verify")]
    [Authorize(Roles = "SysAdmin, LabAdmin")]
    public async Task<IActionResult> Verify(Guid id)
    {
        Client? data = await repo.Clients
            .Include(t => t.TipeUsaha)
            .Include(b => b.BidangUsaha)
            .Include(k => k.Kelurahan.Kecamatan.Kabupaten.Provinsi)
            .FirstOrDefaultAsync(x => x.ClientID == id);
        

        if (data is not null)
        {
            ClientDetailsVM detail = new ClientDetailsVM
            {
                Email = data!.Email,
                Nama = data!.NamaClient,
                TipeUsaha = data!.TipeUsaha.NamaTipe,
                BidangUsaha = data!.BidangUsaha.NamaBidangUsaha,
                Telp = data!.Phone,
                Provinsi = data!.Kelurahan.Kecamatan.Kabupaten.Provinsi.NamaProvinsi,
                Kabupaten = data!.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                Kecamatan = data!.Kelurahan.Kecamatan.NamaKecamatan,
                Kelurahan = data!.Kelurahan.NamaKelurahan,
                Alamat = data!.Alamat,
                NamaPIC = data!.NamaPIC,
                EmailPIC = data!.EmailPIC,
                NIK = data!.NIK,
                PosisiPIC = data!.PosisiPIC,
                TelpPIC = data!.TelpPIC,
                KtpPath = data!.KtpPath,
                RealKtpPath = data!.RealKtpPath,
                SuratKuasaPath = data!.SuratKuasaPath,
                RealSuratKuasaPath = data!.RealSuratKuasaPath,
                IzinPath = data!.DokumenIzinPath,
                RealIzinPath = data!.RealDokumenIzinPath
            };

            return View("~/Views/Client/Verify.cshtml", detail);
        }

        return NotFound();
    }
}
