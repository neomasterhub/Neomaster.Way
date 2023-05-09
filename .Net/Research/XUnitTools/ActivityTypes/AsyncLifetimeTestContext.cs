using Xunit;

namespace XUnitTools.ActivityTypes;

internal class AsyncLifetimeTestContext : IAsyncLifetime
{
    private readonly List<int> _arr = new();

    public async Task DisposeAsync()
    {
        await Task.Run(() => _arr.Clear());
    }

    public async Task InitializeAsync()
    {
        await Task.Run(() => _arr.Add(1));
    }
}
