using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IJenisPengajuan
{
    IQueryable<JenisPengajuan> JenisPengajuans { get; }
}
