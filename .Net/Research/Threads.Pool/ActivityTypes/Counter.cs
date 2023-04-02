namespace Threads.Pool.ActivityTypes;

public class Counter
{
    private int _count = 0;
    public readonly int _to;

    public Counter(CancellationToken cancellationToken, int to = 100)
    {
        CancellationToken = cancellationToken;
        _to = to;
    }

    public int Count => _count;
    public CancellationToken CancellationToken { get; set; }
    public void CountAsync()
    {
        _count++;

        for (int i = 0; i < _to; i++)
        {
            if (CancellationToken.IsCancellationRequested)
            {
                break;
            }

            _count++;
            Thread.Sleep(10);
        }
    }
}
