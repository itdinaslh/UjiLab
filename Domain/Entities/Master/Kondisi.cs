using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("Kondisi")]
public class Kondisi
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int KondisiID { get; set; }

#nullable disable

    [Required(ErrorMessage = "Nama Kondisi Contoh Wajib Diisi")]
    [MaxLength(30)]
    public string NamaKondisi { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
