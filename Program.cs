using RPG_Console;

internal class Program
{
    static void Main(string[] args)
    {
        Character Tadek = new Warrior("Tadek", 3.9, 4.7);
        Tadek.Check_Info();

        Character Ździsio = new Mage("Ździsio", 14);
        Ździsio.Check_Info();

        Ring ring1 = new Ring(0);

        ring1.Battle(Tadek, Ździsio);
    }
}