using RPG_Console;
using static RPG_Console.Living;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Naciśnij Left Alt + Enter");
        Console.WriteLine("(Program będzie czekał, aż to zrobisz)");
        Console.WriteLine("(Po wejściu możesz wyjść wyłączając konsolę, albo naciskając Escape)");

        while (Console.WindowWidth != 209 || Console.WindowHeight != 56)
        {
            Thread.Sleep(200);
        }

        Console.CursorVisible = false;

        //Menu.Draw();

        //Map.Draw();

        //while (true)
        //{
        //    ConsoleKey key = Console.ReadKey(true).Key;
        //    if (key == ConsoleKey.Escape)
        //    {
        //        Console.Clear();
        //        break;
        //    }
        //    Map.Update(key);
        //}

        // Imie może mieć maksymalnie 25 znaków

        Character Knight = new Knight("Arthur", 4, 3);
        Character Mage = new Mage("Salomon", 3, 4);

        BattleGround.Battle(Knight, Mage);

        //Console.ReadKey(true);

        //Console.WriteLine();

        //string a = "...................................................";
        //int b = 0;
        //foreach (var i in a)
        //{
        //    b++;
        //}
        //Console.WriteLine(b);

        //Console.Beep(40, 1000);
        //var key = Console.ReadKey(true);
        //Console.WriteLine(key.Modifiers + " " + key.Key);

        Console.ReadKey(true);
    }
}