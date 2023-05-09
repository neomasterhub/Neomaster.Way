using Xunit;

namespace XUnitTools.ActivityTypes;

public class AsyncLifetimeFixture : IAsyncLifetime
{
    private static List<int> _arr;

    public AsyncLifetimeFixture()
    {
        _arr = new List<int>();
    }

    public IReadOnlyCollection<int> Arr => _arr;

    public async Task InitializeAsync()
    {
        await Task.Run(() => _arr.Add(1));
    }

    public async Task DisposeAsync()
    {
        await Task.Run(() => _arr.Clear());
    }
}
