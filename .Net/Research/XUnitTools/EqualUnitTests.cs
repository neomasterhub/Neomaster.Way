using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class EqualUnitTests
{
    [Fact]
    public void Objects()
    {
        var obj1 = new Box("red", 1);
        var obj2 = new Box("red", 1);

        Assert.Equal(obj1, obj2, new BoxComparer());
        Assert.NotEqual(obj1, obj2);
    }
}
