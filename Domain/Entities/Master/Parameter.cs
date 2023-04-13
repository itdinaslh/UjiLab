using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("Parameter")]
public class Parameter
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ParameterID { get; set; }

#nullable disable

    [MaxLength(100)]
    [Required(ErrorMessage = "Nama parameter harus diisi")]
    public string NamaParameter { get; set; }

    [Required(ErrorMessage = "Pilih jenis parameter")]
    public int JenisParameterID { get; set; }

#nullable enable
    [MaxLength(30)]
    public string? Satuan { get; set; }

    public double? BiayaUji { get; set; } = 0;

    public double? BiayaAlat { get; set; } = 0;

    public bool IsActive { get; set; } = true;    

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

#nullable disable

    public JenisParameter JenisParameter { get; set; }
}