using RPG_Console;
using System.Runtime.Versioning;
using static RPG_Console.Living;

internal class Program
{
    static void Main(string[] args)
    {
        //ReadyGame();

        //Console.WriteLine();
        //string a = "...................................................";
        //int b = 0;
        //foreach (var i in a)
        //{
        //    b++;
        //}
        //Console.WriteLine(b);

        //Console.ReadKey(true);
    }

    public static void ReadyGame()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Aby włączyć grę naciśnij Enter");
        Console.WriteLine("(Program będzie czekał, aż to zrobisz)");
        Console.WriteLine("Naciśnij Left Alt + Enter aby uruchomić pełny ekran");
        Console.WriteLine("(Po wejściu możesz wyjść z gry wyłączając konsolę, albo naciskając Escape)\n\nPsst. Konsola musi mieć szerokość min 109 i wysokość min 39\nGra nie przewiduje w trakcie zmiany wielkośći okna");

        while (true)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Enter) break;
        }

        if (OperatingSystem.IsWindows() && (Console.WindowWidth < 109 || Console.WindowHeight < 39))
        {
            Console.SetWindowSize(109, 39);
        }

        Character Knight = new Knight("Arthur", 4, 3);

        Menu.Draw();

        Console.ReadKey(true);

        Console.CursorVisible = false;

        Map.Draw();

        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
            if (Map.Update(key) == "battle")
            {
                Character Mage = new Mage("Salomon", 3, 4);
                BattleGround.Battle(Knight, Mage);
                Console.ReadKey(true);
                Map.Draw();
                Map.Update(key, true);
            }
        }

        //Console.Beep(40, 1000);
        //var key = Console.ReadKey(true);
        //Console.WriteLine(key.Modifiers + " " + key.Key);
    }
}