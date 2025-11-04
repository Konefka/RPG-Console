using RPG_Console;
using static RPG_Console.Living;

internal class Program
{
    static void Main(string[] args)
    {
        ICharacter Tadek = new Warrior("Tadek", 3.9m, 4.7m);
        Tadek.Check_Info();

        ICharacter Ździsio = new Mage("Ździsio", 14m);
        Ździsio.Check_Info();

        Battleground polana = new Battleground();

        polana.Battle(Ździsio, Tadek);

    }
}