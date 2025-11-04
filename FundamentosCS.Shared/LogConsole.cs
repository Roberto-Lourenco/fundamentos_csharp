using System;
using System.Linq;

namespace FundamentosCS.Shared;

public static class LogConsole
{
    public static void Info(string msg)
    {
        Write(msg, "INFO", ConsoleColor.White);
    }

    public static void Warning(string msg)
    {
        Write(msg, "WARNING", ConsoleColor.Yellow);
    }

    public static void Error(string msg)
    {
        Write(msg, "ERROR", ConsoleColor.Red);
    }

    private static void Write(string msg, string level, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"[LOG {level} {DateTime.Now:HH:mm:ss}] {msg}");
        Console.ResetColor();
    }
}

public static class LogHelper
{
    public static void Info(string component, string eventName, object data)
        => Write(component, eventName, data, LogConsole.Info);

    public static void Warning(string component, string eventName, object data)
        => Write(component, eventName, data, LogConsole.Warning);

    public static void Error(string component, string eventName, object data)
        => Write(component, eventName, data, LogConsole.Error);

    private static void Write(string component, string eventName, object data, Action<string> logAction)
    {
        var properties = data.GetType()
            .GetProperties()
            .Select(p => $"{p.Name}={p.GetValue(data) ?? "null"}");

        var message = $"[{component}] Event={eventName} | {string.Join(" | ", properties)}";
        logAction(message);
    }
}
