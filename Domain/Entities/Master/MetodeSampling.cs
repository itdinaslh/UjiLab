using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("metodesamplings")]
public class MetodeSampling
{
    public int MetodeSamplingID { get; set; }

#nullable disable

    [MaxLength(50)]
    [Required(ErrorMessage = "Nama Metode Sampling Wajib Diisi.")]
    public string NamaMetode { get; set; }

    [MaxLength(25)]
    [Required(ErrorMessage = "Kode Wajib Diisi.")]
    public string Kode { get; set; }

#nullable enable

    [MaxLength(100)]
    public string? Deskripsi { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
