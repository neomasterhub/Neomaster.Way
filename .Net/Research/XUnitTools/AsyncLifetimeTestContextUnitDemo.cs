using TestEngine6;
using Xunit;
using Xunit.Abstractions;
using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class AsyncLifetimeTestContextUnitDemo : UnitDemoBase, IClassFixture<AsyncLifetimeTestContext>
{
    private readonly AsyncLifetimeTestContext _context;

    public AsyncLifetimeTestContextUnitDemo(ITestOutputHelper output, AsyncLifetimeTestContext context)
        : base(output)
    {
        _context = context;
    }
}
