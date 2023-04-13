using DocumentFormat.OpenXml.Office.CoverPageProps;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("JenisPengajuan")]
public class JenisPengajuan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisPengajuanID { get; set; }

#nullable disable

    [MaxLength(25)]
    [Required(ErrorMessage = "Nama jenis pengajuan wajib diisi!")]
    public string NamaJenis { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public List<TipePengajuan> TipePengajuans { get; set; }
}
