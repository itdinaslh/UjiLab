using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("TipePengajuan")]
public class TipePengajuan
{

#nullable disable
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TipePengajuanID { get; set; }

    public string NamaTipe { get; set; }

    public int JenisPengajuanID { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public JenisPengajuan JenisPengajuan { get; set; }

    public List<OutputHasil> OutputHasils { get; set; }
}
