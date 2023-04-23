using System.Text.Json;

namespace DEA.L0.PlatformExtension;

public static class Logger
{
    public static void WriteLineObjectDescription(string description, object obj)
    {
        var objTypeName = obj.GetType().Name;

        Console.WriteLine($"[ {description} ]");
        Console.Write($"\"{objTypeName}\": ");
        Console.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true }));
        Console.WriteLine();
    }
}
