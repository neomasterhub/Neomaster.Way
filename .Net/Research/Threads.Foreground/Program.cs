var foreground = new Thread(() =>
{
    var i = 5;
    while (i-- > 0)
    {
        Console.Write('F');
        Thread.Sleep(1000);
    }
});

Console.WriteLine($"is background: {foreground.IsBackground}"); // is background: False

foreground.Start();

Console.Write('M');

// Output: MFFFFF
