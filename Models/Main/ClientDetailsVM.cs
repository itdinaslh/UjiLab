using System.ComponentModel.DataAnnotations;

namespace UjiLab.Models;

public class ClientDetailsVM
{

#nullable disable
    public Guid ClientID { get; set; }

    public string Email { get; set; }

    public string Nama { get; set; }

    public string TipeUsaha { get; set; }

    public string BidangUsaha { get; set; }

    public string Telp { get; set; }

    public string Provinsi { get; set; }

    public string Kabupaten { get; set; }

    public string Kecamatan { get; set; }

    public string Kelurahan { get; set; }

    public string Alamat { get; set; }

    public string NamaPIC { get; set; }

    public string NIK { get; set; }

    public string EmailPIC { get; set; }

    public string PosisiPIC { get; set; }

    public string TelpPIC { get; set; }

    public string KtpPath { get; set; }

    public string RealKtpPath { get; set; }

    public string SuratKuasaPath { get; set; }

    public string RealSuratKuasaPath { get; set; }

    [Required(ErrorMessage = "Silahkan pilih status")]
    public int StatusID { get; set; }

    public string Keterangan { get; set; }

#nullable enable

    public string? IzinPath { get; set; }

    public string? RealIzinPath { get; set; }
}
