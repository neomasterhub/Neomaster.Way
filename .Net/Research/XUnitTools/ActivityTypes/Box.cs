namespace XUnitTools.ActivityTypes;

internal class Box
{
    public Box(string color, int size)
    {
        Color = color;
        Size = size;
    }

    public string Color { get; set; }
    public int Size { get; set; }
}
