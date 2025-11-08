using RPG_Console;
using static RPG_Console.Living;

internal class Program
{
    static void Main(string[] args)
    {

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

        //Thread.Sleep(1000);
        //Console.Beep(40, 1000);
    }
}