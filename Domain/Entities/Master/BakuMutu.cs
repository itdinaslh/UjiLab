using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("baku_mutu")]
public class BakuMutu
{
#nullable disable
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BakuMutuID { get; set; }

    [MaxLength(50)]
    [Required(ErrorMessage = "Nama baku mutu wajib diisi!")]
    public string NamaBakuMutu { get; set; }

    [Required(ErrorMessage = "Output hasil wajib dipilih")]
    public int OutputHasilID { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public OutputHasil OutputHasil { get; set; }

}
