var background = new Thread(() =>
{
    var i = 5;
    while (i-- > 0)
    {
        Console.Write('B');
        Thread.Sleep(1000);
    }
})
{
    IsBackground = true, // !
};

background.Start();

Console.Write('M');

// Output: MB
