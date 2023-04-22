using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools.Asserts;

public class SameUnitTests
{
    [Fact]
    public void Objects()
    {
        var o1 = new Box("red", 1);
        var o2 = new Box("red", 1);

        Assert.NotSame(o1, o2);
    }

    [Fact]
    public void Strings()
    {
        var s1 = "test";
        var s2 = "test";
        var s3 = new string(s1);

        Assert.Same(s1, s2);
        Assert.NotSame(s1, s3);
    }
}
