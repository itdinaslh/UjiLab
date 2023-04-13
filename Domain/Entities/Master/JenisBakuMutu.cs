using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("JenisBakuMutu")]
public class JenisBakuMutu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisBakuMutuID { get; set; }

#nullable disable

    [MaxLength(150)]
    [Required(ErrorMessage = "Nama Jenis Baku Mutu Wajib Diisi")]
    public string NamaJenis { get; set; }

#nullable enable

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;    
}
