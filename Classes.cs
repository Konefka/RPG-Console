using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
    abstract class Character : ICheck
    {
        public string? Name;
        public double Power;
        public double HP;

        public virtual void Check_Info()
        {
            Console.WriteLine($"Ta postać ma statystyki:");
            Console.WriteLine($"- Name: {Name}");
            Console.WriteLine($"- Power: {Power}");
            Console.WriteLine($"- HP: {HP}");
        }

        public virtual void Attack(Character target)
        {
            if (target != null)
            {
                Console.WriteLine($"You attack {target.Name} for {Power} damage");
                target.HP -= Power;
            }
            else
            {
                Console.WriteLine("Nie ma takiej postaci");
            }
        }
    }

    class Warrior : Character
    {
        public double Sword_weight;
        public double Sword_power;
        public Warrior(string name, double power, double sword_weight)
        {
            Name = name;
            Power = power < 10 ? power : 10;
            HP = Power * 10;
            Sword_weight = sword_weight < 5 ? sword_weight : 5;
            Sword_power = Math.Round((Power / Sword_weight) * 4);
            Power = Sword_power;
        }

        public override void Check_Info()
        {
            base.Check_Info();
            Console.WriteLine($"- Sword weight: {Sword_weight}");
            Console.WriteLine($"- Sword power: {Sword_power}");
        }

        public override void Attack(Character target)
        {
            if (target != null)
            {
                Console.WriteLine($"You attack {target.Name} for {Sword_power} damage");
                target.HP -= Sword_power;
            }
            else
            {
                Console.WriteLine("Nie ma takiej postaci");
            }
        }
    }

    class Mage : Character
    {
        public Mage(string name, double magic_power)
        {
            Name = name;
            Power = magic_power < 10 ? magic_power : Math.Round(magic_power / 2);
            HP = Power * 5;
        }
    }

    class Archer : Character
    {
        public Archer(string name, double arrow_power)
        {
            Name = name;
            Power = arrow_power < 10 ? arrow_power : Math.Round(arrow_power / 2);
            HP = Power * 5;
        }
    }

    class Ring : Character
    {
        private double Battle_To_What_Hp;
        public Ring(double battle_to_what_hp)
        {
            Battle_To_What_Hp = battle_to_what_hp;
        }

        public void Battle(Character you, Character target)
        {
            if (you != null && target != null)
            {
                int who_is_next = 1;
                while (true)
                {
                    if (who_is_next == 1)
                    {
                        Console.WriteLine($"=========={you.Name}==========");
                        Console.WriteLine($"{you.Name} attacks {target.Name} for {you.Power} HP");
                        Console.Write($"{target.HP} HP - {you.Power} HP = ");
                        Math.Round(target.HP -= you.Power, 2);
                        Console.WriteLine(target.HP + " HP");
                        who_is_next++;
                    }
                    else if (who_is_next == 2)
                    {
                        Console.WriteLine($"=========={target.Name}==========");
                        Console.WriteLine($"{target.Name} attacks {you.Name} for {target.Power} HP");
                        Console.Write($"{you.HP} HP - {target.Power} HP = ");
                        Math.Round(you.HP -= target.Power, 2);
                        Console.WriteLine(you.HP + " HP");
                        who_is_next--;
                    }

                    if (you.HP <= Battle_To_What_Hp)
                    {
                        Console.WriteLine($"BRAWO! Pojedynek wygrał {target.Name} z {target.HP} HP");
                        break;
                    }
                    else if (target.HP <= Battle_To_What_Hp)
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