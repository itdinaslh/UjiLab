using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("JenisParameter")]
public class JenisParameter
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JenisParameterID { get; set; }

#nullable disable

    [MaxLength(30)]
    public string NamaJenis { get; set; }

    public List<Parameter> Parameters { get; set; }
}
