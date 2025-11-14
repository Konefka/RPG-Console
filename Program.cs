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

        //Console.CursorVisible = false;

        //Menu.Draw();

        //Console.ReadKey(true);

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

        Character a = new Warrior("Wisio", 4, 3);
        Character b = new Mage("Zdzisio", 3, 4);

        BattleGround.Battle(a, b);

        //Console.Beep(40, 1000);
        //var key = Console.ReadKey(true);
        //Console.WriteLine(key.Modifiers + " " + key.Key);
    }
}