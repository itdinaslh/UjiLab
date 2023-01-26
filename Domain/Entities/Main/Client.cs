using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("clients")]
public class Client
{
    [Key]
    public Guid ClientID { get; set; } = Guid.Empty;

    [Required]
    public Guid UserID { get; set; }

#nullable disable

    [Required(ErrorMessage = "Email wajib diisi!")]
    [MaxLength(150)]
    public string Email { get; set; }

    [MaxLength(255)]
    [Required(ErrorMessage = "Nama wajib diisi!")]
    public string NamaClient { get; set; }

    [Required(ErrorMessage = "Tipe usaha wajib diisi!")]
    public int TipeUsahaID { get; set; }

    public int BidangUsahaID { get; set; }

    [MaxLength(25)]
    [Required(ErrorMessage = "No Telp wajib diisi!")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Kelurahan wajib diisi")]
    [MaxLength(15)]
    public string KelurahanID { get; set; }

    [MaxLength(255)]
    [Required(ErrorMessage = "Alamat wajib diisi!")]
    public string Alamat { get; set; }

    [MaxLength(150)]
    [Required(ErrorMessage = "Nama PIC wajib diisi")]
    public string NamaPIC { get; set; }

    [Required(ErrorMessage = "NIK / No KTP wajib diisi!")]
    [Range(0, 9999999999999999, ErrorMessage = "Masukan format NIK dengan benar")]
    [StringLength(16, MinimumLength = 16, ErrorMessage = "NIK harus 16 karakter")]
    public string NIK { get; set; }

    [Required(ErrorMessage = "Posisi PIC wajib diisi!")]
    [MaxLength(75)]
    public string PosisiPIC { get; set; }

    [Required(ErrorMessage = "Email PIC wajib diisi!")]
    [MaxLength(150)]
    public string EmailPIC { get; set; }

    [Required(ErrorMessage = "Telp PIC wajib diisi")]
    [MaxLength(25)]
    public string TelpPIC { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "File KTP PIC wajib diupload")]
    public string KtpPath { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    public string RealKtpPath { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Surat Kuasa / Keterangan wajib diupload!")]
    public string SuratKuasaPath { get; set; } = string.Empty;

    [DataType(DataType.Text)]
    public string RealSuratKuasaPath { get; set; } = string.Empty;

#nullable enable

    [DataType(DataType.Text)]    
    public string? DokumenIzinPath { get; set; }

    [DataType(DataType.Text)]
    public string? RealDokumenIzinPath { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

#nullable disable

    public int StatusID { get; set; }

    public bool IsVerified { get; set; } = false;

    public TipeUsaha TipeUsaha { get; set; }

    public BidangUsaha BidangUsaha { get; set; }

    public Kelurahan Kelurahan { get; set; }

    public Status Status { get; set; }

}
