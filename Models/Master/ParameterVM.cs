using UjiLab.Domain.Entities;

namespace UjiLab.Models;

public class ParameterVM
{
#nullable disable

    public Parameter Parameter { get; set; }

    public List<JenisParameter> JenisParameters { get; set; }

#nullable enable

    public string? Jenis { get; set; }
}
