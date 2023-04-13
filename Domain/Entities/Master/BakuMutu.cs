using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("BakuMutu")]
public class BakuMutu
{
#nullable disable
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint BakuMutuID { get; set; }

    public int OutputHasilID { get; set; }

    public int ParameterID { get; set; }

#nullable enable
    public int? MetodeParameterID { get; set; }

    public int? JenisBakuMutuID { get; set; }

#nullable disable

    public double BiayaUji { get; set; } = 0;

    public double BiayaAlat { get; set; } = 0;    

#nullable enable

    public string? NilaiBakuMutu { get; set; }

#nullable disable

    public bool IsActive { get; set; } = true;

    public Parameter Parameter { get; set; }

    public OutputHasil OutputHasil { get; set; }

#nullable enable

    public MetodeParameter? MetodeParameter { get; set; }

    public JenisBakuMutu? JenisBakuMutu { get; set; }

    [MaxLength(75)]
    public string? CreatedBy { get; set; } = "system";

    [MaxLength(75)]
    public string? UpdatedBy { get; set; } = "system";

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

}
