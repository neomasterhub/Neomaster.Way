using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class EqualUnitTests
{
    [Fact]
    public void Objects()
    {
        var o1 = new Box("red", 1);
        var o2 = new Box("red", 1);

        Assert.Equal(o1, o2, new BoxComparer());
        Assert.NotEqual(o1, o2);
    }

    [Fact]
    public void Structs()
    {
        Signal s1 = new();
        Signal s2 = new();

        Assert.Equal(s1, s2);
    }
}
