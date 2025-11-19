using RPG_Console;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using static RPG_Console.Living;

internal class Program
{
    static void Main(string[] args)
    {
        ReadyGame();
    }

    public static void ReadyGame()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("- Aby włączyć grę naciśnij Enter");
        Console.WriteLine("(Program będzie czekał, aż to zrobisz)\n");
        Console.WriteLine("- Naciśnij Left Alt + Enter aby uruchomić pełny ekran");
        Console.WriteLine("(Po wejściu możesz wyjść z gry wyłączając konsolę, albo naciskając Escape)\n");
        Console.WriteLine("Psst. Konsola musi mieć szerokość minimum 109 i wysokość minimum 39\nGra nie przewiduje zmiany wielkości okna w trakcie gry");

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

        CancellationTokenSource cts = new CancellationTokenSource();
        Task.Run(() => Menu.AnimateStars(cts.Token));

        Console.ReadKey(true);
        cts.Cancel();

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
            string return_value = Map.Update(key);
            if (return_value == "battle")
            {
                Character Mage = new Mage("Salomon", 3, 4);
                BattleGround.Battle(Knight, Mage);
                Console.ReadKey(true);
                Map.Draw();
                Map.Update(key, true);
            }
            else if (return_value == "win" && OperatingSystem.IsWindows())
            {
                Console.Beep(800, 110);
                Console.Beep(800, 1000);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2);
                Console.Write("You won!");
                Console.SetCursorPosition(1,0);
                return;
            }
        }

        //var key = Console.ReadKey(true);
        //Console.WriteLine(key.Modifiers + " " + key.Key);
    }
}