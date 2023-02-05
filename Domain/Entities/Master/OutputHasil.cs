using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("output_hasil")]
public class OutputHasil
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OutputHasilID { get; set; }

#nullable disable

    [MaxLength(100)]
    [Required(ErrorMessage = "Nama output hasil uji wajib diisi")]
    public string OutputName { get; set; }

    [Required(ErrorMessage = "Tipe pengajuan wajib dipilih")]
    public int TipePengajuanID { get; set; }

    [MaxLength(25)]
    [Required(ErrorMessage = "Kode wajib diisi")]
    public string Kode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public TipePengajuan TipePengajuan { get; set; }

    public List<BakuMutu> BakuMutus { get; set; }

}
