using RPG_Console;
using static RPG_Console.Living;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Naciśnij Left Alt + Enter");
        Console.WriteLine("(Program będzie czekał, aż to zrobisz)");

        while (Console.WindowWidth != 209 || Console.WindowHeight != 56)
        {
            Thread.Sleep(200);
        }

        Map.DrawLobby();

        Map.Draw();

        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                break;
            }
            Map.Update(key);
        }

        //Console.Beep(40, 1000);
    }
}