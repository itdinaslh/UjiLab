using UjiLab.Domain.Entities;

namespace UjiLab.Models;

public class BakuMutuVM
{

#nullable disable

    public BakuMutu BakuMutu { get; set; } = new BakuMutu();

    public int JenisPengajuanID { get; set; }

    public string NamaJenisPengajuan { get; set; }

    public int TipePengajuanID { get; set; }

    public string NamaTipePengajuan { get; set; }

    public int OutputHasilID { get; set; }

    public string OutputName { get; set; }
}
