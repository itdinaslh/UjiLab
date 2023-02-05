using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UjiLab.Domain.Entities;

[Table("tipe_lokasi")]
public class TipeLokasi
{
#nullable disable

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TipeLokasiID { get; set; }

    [MaxLength(50)]
    [Required(ErrorMessage = "Nama tipe lokasi wajib diisi!")]
    public string NamaTipe { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
