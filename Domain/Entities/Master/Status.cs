using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("Status")]
public class Status
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StatusID { get; set; }

#nullable disable

    [MaxLength(50)]
    [Required]
    public string StatusName { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public List<Client> Clients { get; set; }
}
