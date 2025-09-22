
using Infrastructure.Interfaces;

namespace Infrastructure.Helpers.VG;

public class IdGenerator : IUniqueIdGenerator
{
    public static string Generate()
    {
        return Guid.NewGuid().ToString();
    }
}
