using XUnitTools.ActivityTypes;

namespace XUnitTools;

public class DisposableTestingUnitTests : IDisposable
{
    private readonly Stacks _stacks;

    public DisposableTestingUnitTests()
    {
        _stacks = new Stacks();
    }

    public void Dispose()
    {
        _stacks.Dispose();
    }
}
