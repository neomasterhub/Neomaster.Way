namespace XUnitTools.ActivityTypes;

internal class Stacks : IDisposable
{
    public static List<int> Ints = new();

    public void Dispose()
    {
        Ints.Clear();
    }
}
