using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("TipeUsaha")]
public class TipeUsaha
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TipeUsahaID { get; set;}

#nullable disable

    [MaxLength(30)]
    [Required]
    public string NamaTipe { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<Client> Clients { get; set; }
}
