using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
    class Living
    {
        public abstract class Hero : ICharacter
        {
            public string? Name { get; protected set; }
            public decimal Power { get; protected set; }
            public decimal HP { get; protected set; }

            public virtual void Check_Info()
            {
                Console.WriteLine($"Ta postać ma statystyki:");
                Console.WriteLine($"- Name: {Name}");
                Console.WriteLine($"- Power: {Power}");
                Console.WriteLine($"- HP: {HP}");
            }

            decimal ICharacter.TakeDamage(decimal howmuch)
            {
                HP = Math.Round(HP - howmuch, 2);
                if (HP < 0) HP = 0;
                return HP;
            }

            decimal ICharacter.HealUp(decimal howmuch)
            {
                return HP = Math.Round(HP + howmuch, 2);
            }
        }

        public class Warrior : Hero
        {
            public decimal Sword_weight;
            public decimal Sword_power;
            public Warrior(string name, decimal power, decimal sword_weight)
            {
                Name = name;
                Power = power < 10 ? power : 10;
                HP = Power * 10;
                Sword_weight = sword_weight < 5 ? sword_weight : 5;
                Sword_power = Math.Round((Power / Sword_weight) * 4, 2);
                Power = Sword_power;
            }

            public override void Check_Info()
            {
                base.Check_Info();
                Console.WriteLine($"- Sword weight: {Sword_weight}");
                Console.WriteLine($"- Sword power: {Sword_power}");
            }
        }

        public class Mage : Hero
        {
            public Mage(string name, decimal magic_power)
            {
                Name = name;
                Power = magic_power < 10 ? magic_power : Math.Round(magic_power / 2, 2);
                HP = Power * 5;
            }
        }

        public class Archer : Hero
        {
            public Archer(string name, decimal arrow_power)
            {
                Name = name;
                Power = arrow_power < 10 ? arrow_power : Math.Round(arrow_power / 2, 2);
                HP = Power * 5;
            }
        }
    }

    class Undead
    {
        public abstract class Demon : ICharacter
        {
            public string? Name { get; protected set; }
            public decimal Power { get; protected set; }
            public decimal HP { get; protected set; }

            public virtual void Check_Info()
            {
                Console.WriteLine($"Ta postać ma statystyki:");
                Console.WriteLine($"- Name: {Name}");
                Console.WriteLine($"- Power: {Power}");
                Console.WriteLine($"- HP: {HP}");
            }

            decimal ICharacter.TakeDamage(decimal howmuch)
            {
                HP = Math.Round(HP - howmuch, 2);
                if (HP < 0) HP = 0;
                return HP;
            }

            decimal ICharacter.HealUp(decimal howmuch)
            {
                return HP = Math.Round(HP + howmuch, 2);
            }
        }
    }

    class Battleground
    {
        public void Battle(ICharacter you, ICharacter target)
        {
            if (you != null && target != null)
            {
                int who_is_next = 1;
                while (true)
                {
                    if (who_is_next == 1)
                    {
                        Console.WriteLine($"====={you.Name}=====");
                        Console.WriteLine($"{you.Name} attacks {target.Name} for {you.Power} HP");
                        Console.Write($"{target.HP} HP - {you.Power} HP = ");
                        Console.WriteLine(target.TakeDamage(you.Power) + " HP");
                        who_is_next++;
                    }
                    else if (who_is_next == 2)
                    {
                        Console.WriteLine($"====={target.Name}=====");
                        Console.WriteLine($"{target.Name} attacks {you.Name} for {target.Power} HP");
                        Console.Write($"{you.HP} HP - {target.Power} HP = ");
                        Console.WriteLine(you.TakeDamage(target.Power) + " HP");
                        who_is_next--;
                    }

                    if (you.HP <= 0)
                    {
                        Console.WriteLine($"BRAWO! Pojedynek wygrał {target.Name} z {target.HP} HP");
                        break;
                    }
                    else if (target.HP <= 0)
                    {
                        Console.WriteLine($"BRAWO! Pojedynek wygrał {you.Name} z {you.HP} HP");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Nie ma takiej postaci");
            }
        }
    }
}