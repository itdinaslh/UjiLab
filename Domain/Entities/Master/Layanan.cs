using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("Layanan")]
public class Layanan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LayananID { get; set; }

#nullable disable

    [Required(ErrorMessage = "Nama Layanan Wajib Diisi")]
    [MaxLength(30)]
    public string NamaLayanan { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
