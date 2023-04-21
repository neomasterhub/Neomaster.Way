using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class SameUnitTests
{
    [Fact]
    public void Objects()
    {
        var o1 = new Box("red", 1);
        var o2 = new Box("red", 1);

        Assert.NotSame(o1, o2);
    }
}
