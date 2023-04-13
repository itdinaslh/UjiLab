using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("MetodeParameter")]
public class MetodeParameter
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MetodeParameterID { get; set; }

#nullable disable

    [MaxLength(150)]
    [Required(ErrorMessage = "Nama metode paramater wajib diisi")]
    public string NamaMetode { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
