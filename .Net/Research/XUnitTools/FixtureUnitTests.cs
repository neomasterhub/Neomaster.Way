using Xunit;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class FixtureUnitTests : IClassFixture<AsyncLifetimeFixture>
{
    private readonly AsyncLifetimeFixture _fixture;

    public FixtureUnitTests(AsyncLifetimeFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test1() => Assert.Equal(1, _fixture.Count);

    [Fact]
    public void Test2() => Assert.Equal(1, _fixture.Count);

    [Fact]
    public void Test3() => Assert.Equal(1, _fixture.Count);
}
