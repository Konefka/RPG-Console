using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
    internal abstract class Character
    {
        public string? Name { get; protected set; }
        public decimal Power { get; protected set; }
        public decimal HP { get; protected set; }

        public virtual void Check_Info()
        {
            Console.WriteLine($"{Name} ma statystyki:");
            Console.WriteLine($"- Power: {Power}");
            Console.WriteLine($"- HP: {HP}");
        }

        internal virtual decimal TakeDamage(decimal howmuch)
        {
            HP = Math.Round(HP - howmuch, 2);
            if (HP < 0) HP = 0;
            return HP;
        }

        internal virtual decimal HealUp(decimal howmuch)
        {
            return HP = Math.Round(HP + howmuch, 2);
        }
    }

    class Living
    {
        public class Warrior : Character
        {
            public decimal Sword_weight { get; protected set; }
            public Warrior(string name, decimal power, decimal sword_weight)
            {
                Name = name;
                Power = Math.Round(power <= 15 ? power : 15, 2);
                HP = Power * 10;
                Sword_weight = Math.Round(sword_weight <= 5 ? sword_weight : 5, 2);
                Power = Math.Round((Power / Sword_weight) * 4, 2);
            }

            public override void Check_Info()
            {
                base.Check_Info();
                Console.WriteLine($"- Sword weight: {Sword_weight}");
            }
        }

        public class Archer : Character
        {
            public decimal Arrow_power { get; protected set; }
            public Archer(string name, decimal human_power, decimal arrow_power)
            {
                Name = name;
                Power = Math.Round(human_power <= 10 ? human_power : 10, 2);
                HP = Power * 10;
                Arrow_power = Math.Round(arrow_power <= 3 ? arrow_power : 3, 2);
                Power = Math.Round(Power * Arrow_power, 2);
            }

            public override void Check_Info()
            {
                base.Check_Info();
                Console.WriteLine($"- Arrow power: {Arrow_power}");
            }
        }

        public class Mage : Character
        {
            public decimal Magic_power { get; protected set; }
            public Mage(string name, decimal human_power, decimal magic_power)
            {
                Name = name;
                Power = Math.Round(human_power <= 10 ? human_power : 10, 2);
                HP = Power * 10;
                Magic_power = Math.Round(magic_power <= 3 ? magic_power : 3, 2);
                Power = Math.Round(Power * Magic_power, 2);
            }

            public override void Check_Info()
            {
                base.Check_Info();
                Console.WriteLine($"- Magic power: {Magic_power}");
            }
        }
    }

    class Battleground
    {
        public void Battle(Character you, Character target)
        {
            if (you != null && target != null)
            {
                int who_is_next = 1;
                while (you.HP > 0 && target.HP > 0)
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
                }

                if (you.HP <= 0)
                {
                    Console.WriteLine($"BRAWO! Pojedynek wygrał {target.Name} z {target.HP} HP");
                }
                else if (target.HP <= 0)
                {
                    Console.WriteLine($"BRAWO! Pojedynek wygrał {you.Name} z {you.HP} HP");
                }
            }
            else
            {
                Console.WriteLine("Nie ma takiej postaci");
            }
        }
    }
}