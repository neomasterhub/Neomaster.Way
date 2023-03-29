var foreground = new Thread(() =>
{
    var i = 5;
    while (i-- > 0)
    {
        Console.Write('F');
        Thread.Sleep(1000);
    }
});

Console.WriteLine($"F is background: {foreground.IsBackground}");
Console.Write('M');

foreground.Start();

// Output:
// F is background: False
// MFFFFF
