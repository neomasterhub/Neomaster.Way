using System.Diagnostics.CodeAnalysis;

namespace XUnitTools.ActivityTypes;

internal class BoxComparer : IEqualityComparer<Box>
{
    public bool Equals(Box x, Box y)
    {
        return x.Color == y.Color && x.Size == y.Size;
    }

    public int GetHashCode([DisallowNull] Box obj) => obj.GetHashCode();
}
