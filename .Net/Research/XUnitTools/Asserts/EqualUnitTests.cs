using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools.Asserts;

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
    public void ObjectSequences()
    {
        var s1 = new Box[] { new("red", 1) };
        var s2 = new List<Box> { new("red", 1) };

        Assert.Equal(s1, s2, new BoxComparer());
        Assert.NotEqual(s1, s2);
    }

    [Fact]
    public void Structs()
    {
        var s1 = new Coords(1, 2);
        var s2 = new Coords(1, 2);

        Assert.Equal(s1, s2);
    }

    [Fact]
    public void StructSequences()
    {
        var s1 = new int[] { 1, 2, 3 };
        var s2 = new List<int> { 1, 2, 3 };

        Assert.Equal(s1, s2);
    }
}
