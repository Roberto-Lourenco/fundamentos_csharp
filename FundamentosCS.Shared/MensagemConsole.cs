namespace FundamentosCS.Shared;
public static class MensagemConsole
{
    public static void errorMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    public static void normalMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    public static void successMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    public static void warningMsg(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
}

