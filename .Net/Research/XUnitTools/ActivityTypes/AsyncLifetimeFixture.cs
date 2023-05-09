﻿using Xunit;

namespace XUnitTools.ActivityTypes;

public class AsyncLifetimeFixture : IAsyncLifetime
{
    private static readonly List<int> _arr = new();

    public IReadOnlyCollection<int> Arr => _arr;

    public async Task DisposeAsync()
    {
        await Task.Run(() => _arr.Clear());
    }

    public async Task InitializeAsync()
    {
        await Task.Run(() => _arr.Add(1));
    }
}
