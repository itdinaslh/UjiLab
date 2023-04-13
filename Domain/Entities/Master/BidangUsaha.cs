using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjiLab.Domain.Entities;

[Table("BidangUsaha")]
public class BidangUsaha
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BidangUsahaID { get; set; }

#nullable disable

    public string NamaBidangUsaha { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public List<Client> Clients { get; set; }
}
