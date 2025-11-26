using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
    static class BattleGround
    {
        public static void Beatles(Character you, Character target)
        {
            Character who_is_next = you;
            while (you.HP > 0 && target.HP > 0)
            {
                if (who_is_next == you)
                {
                    Console.WriteLine($"====={you.Name}=====");
                    Console.WriteLine($"{you.Name} attacks {target.Name} for {you.Power} HP");
                    Console.Write($"{target.HP} HP - {you.Power} HP = ");
                    Console.WriteLine(target.TakeDamage(you.Power) + " HP");
                    who_is_next = target;
                }
                else if (who_is_next == target)
                {
                    Console.WriteLine($"====={target.Name}=====");
                    Console.WriteLine($"{target.Name} attacks {you.Name} for {target.Power} HP");
                    Console.Write($"{you.HP} HP - {target.Power} HP = ");
                    Console.WriteLine(you.TakeDamage(target.Power) + " HP");
                    who_is_next = you;
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

        public static void Battle(Character you, Character target)
        {
            BattleDisplay battle = new BattleDisplay(you, target);
            battle.Draw();
            Character who_is_next = you;
            //Console.ReadKey(true);
        }
    }
}