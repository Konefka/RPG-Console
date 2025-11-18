using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
    static class ArtAssets
    {
        public static readonly string[] Start = {
            @"  ++%%%%%%##::  ++%%%%%%%%%%%%%%##     ++%%%%        %%%%%%%%%%##,,   ++%%%%%%%%%%%%%%##",
            @"**%%##++++%%%%  ::++++++%%##++++**     %%##%%::      %%%%++++++%%%%,, ::++++++%%##++++**",
            @"##%%..    ..,,          %%++         ,,%%::%%++      %%##      **%%**         %%++      ",
            @"++%%,,                  %%++         **%%..++%%      %%##      ::%%++         %%++      ",
            @"::%%%%++,,              %%++         ####  **%%,,    %%##      ::%%**         %%++      ",
            @"  ,,##%%%%++..          %%++       ..%%++  ,,%%**    %%%%++++++%%%%..         %%++      ",
            @"      ::##%%##          %%++       ::%%++++++%%##    %%%%%%%%%%%%,,           %%++      ",
            @"          ++%%,,        %%++       ++%%%%%%%%%%%%    %%##    ++%%,,           %%++      ",
            @"..        ++%%::        %%++       %%##      ::%%::  %%##    ::%%++           %%++      ",
            @"%%##++++++%%%%          %%++     ,,%%**        %%++  %%##      ##%%,,         %%++      ",
            @"++##%%%%%%##,,          %%++     ++%%,,        ##%%  %%##      ::%%++         %%++      "
        };
        public static readonly string[] Battle = {
            @"%%%%%%%%%##,,          ++%%%%    ++%%%%%%%%%%%%%%## ++%%%%%%%%%%%%%%##  %%++              ++%%%%%%%%%%%%##",
            @"%%%%++++++%%%%         %%##%%::  ::++++++%%##++++** ::++++++%%##++++**  %%++              %%**++++++++++::",
            @"%%##      **%%,      ,,%%::%%++          %%++               %%++        %%++              %%++            ",
            @"%%##      ::##       **%%..++%%          %%++               %%++        %%++              %%++            ",
            @"%%%%++++++**..       ####  **%%,,        %%++               %%++        %%++              %%**++++++++,,  ",
            @"%%%%%%%%%%##::     ..%%++  ,,%%**        %%++               %%++        %%++              ++%%%%%%%%%%##  ",
            @"%%##      %%%**    ::%%++++++%%##        %%++               %%++        %%++              %%++            ",
            @"%%##      ::%%++   ++%%%%%%%%%%%%        %%++               %%++        %%++              %%++            ",
            @"%%##      ::%%**   %%##      ::%%::      ##==               %%++        %%++              %%++            ",
            @"%%**++++++%%%..  ,,%%**        %%++      ##==               %%++        %%**++++++++++::  %%**++++++++++::",
            @"%%%%%%%%%%%%:`   ++%%,,        ##%%      ##==               %%++        ++%%%%%%%%%%%%##  ++%%%%%%%%%%%%##"
        };
        public static readonly string[] KnightIdle = {
            @"        _,.                      ",
            @"      ,` -.)                     ",
            @"     (`_/-\\-..__,             , ",
            @"    /,| `--._,-+>|           ,'| ",
            @"    \_|  |`-._./||          /  / ",
            @"      |   `-,  / |         /  /  ",
            @"      |      ||  |        /  /   ",
            @"       `r-._ || /        /  /    ",
            @"   __,--<_     )`>,--.  /  /     ",
            @" .`   \   `---'   \   :/  /      ",
            @" |     |           \  /  /       ",
            @" :     /           ;_/  /        ",
            @"  \_/`` \          :/  /         ",
            @"   |     |   ___--`/  /          ",
            @"   |     ,```   (``--..          ",
            @"    \,.-->.._    ``--..)         ",
            @"    (        `-.(```}            ",
            @"     `*-.______(...}             ",
            @"       |           :             "
        };
        //public static readonly string[] KnightReady = {};
        //public static readonly string[] KnightAttack = {};
        public static readonly string[] MageIdle = {
            @"                     ,-----.     ",
            @"                    /      |     ",
            @"              ____,'       |__   ",
            @"            <   -'         :   > ",
            @"             `-.__..--'``-,_\_`  ",
            @"                |o/ ` o,.)_`>    ",
            @"                :/ `     ||/)    ",
            @"                (_.).__,-` |     ",
            @"                /( `.``   `|     ",
            @"                |'`-.)  `  ;     ",
            @" ,___..___     /|     `  /  `:.  ",
            @" |-.__\\  ``-./ |  `    : , `. : ",
            @" :`\  `\\  \ :  (   `  /|    | | ",
            @"  \ \   \\   |  | `   : :    .\: ",
            @"  : `\_  ))  :  ;     | |    );| ",
            @" (`-.-'\ ||  |\ \   ` ; ;     |: ",
            @"  \-_   `;;._   ( `  / /_     || ",
            @"   `-.-.// ,'`-._\__/,'(      ;| ",
            @"       || |    (     ,' /   /  | "
        };

    }
    static class Menu
    {
        static int Rows;
        static int Cols;
        static List<List<char>> MenuDisplay = new List<List<char>>();
        static List<(int row, int col)> sPos = new List<(int, int)>();

        public static void Generate(int rows, int cols)
        {
            MenuDisplay.Clear();

            Rows = rows;
            Cols = cols;

            for (int row = 0; row < Rows; row++)
            {
                List<char> newRow = new List<char>();

                for (int col = 0; col < Cols; col++)
                {
                    newRow.Add('.');
                }
                MenuDisplay.Add(newRow);
            }

            sPos.Clear();

            for (int i = 0; i < Rows * 2; i++)
            {
                sPos.Add((Random.Shared.Next(1, Rows - 1), Random.Shared.Next(1, Cols - 1)));
            }
        }
        public static void Draw()
        {
            if (!MenuDisplay.Any())
            {
                Generate(Console.WindowHeight, Console.WindowWidth);
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int row = 0; row < MenuDisplay.Count; row++)
            {
                for (int col = 0; col < MenuDisplay[0].Count; col++)
                {
                    if (sPos.Contains((row, col)))
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                if (row != MenuDisplay.Count - 1)
                {
                    Console.WriteLine();
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < ArtAssets.Start.Length; i++)
            {
                Console.SetCursorPosition((Cols / 2 - ArtAssets.Start[0].Length / 2) + 2, (Rows / 2 - 1) + i - (ArtAssets.Start.Length / 2));
                Console.Write(ArtAssets.Start[i]);
            }
        }
    }
    static class Map
    {
        static int Rows = 30;
        static int Cols = 120;
        static int pRow;
        static int pCol;
        static List<(int row, int col)> ePos = new List<(int, int)>();
        static List<List<char>> MapDisplay = new List<List<char>>();

        public static void Generate(int rows, int cols)
        {
            MapDisplay.Clear();

            Rows = rows;
            Cols = cols / 2;

            pRow = Random.Shared.Next(0, Rows - 1);
            pCol = Random.Shared.Next(1, Cols - 1);

            for (int row = 0; row < Rows; row++)
            {
                List<char> newRow = new List<char>();

                for (int col = 0; col < Cols; col++)
                {
                    if (row == 0 || row == Rows - 1 || col == 0 || col == Cols - 1)
                        newRow.Add('#');
                    else
                        newRow.Add('.');
                }
                MapDisplay.Add(newRow);
            }

            GenerateEnemies(Rows / 4);
        }

        public static void Draw()
        {
            if (!MapDisplay.Any())
            {
                Generate(Console.WindowHeight, Console.WindowWidth);
            }

            Console.Clear();

            for (int row = 0; row < MapDisplay.Count; row++)
            {
                for (int col = 0; col < MapDisplay[0].Count; col++)
                {
                    if (row == pRow && col == pCol)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@ ");
                    }
                    else if (ePos.Contains((row, col)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("E ");
                    }
                    else
                    {
                        if (MapDisplay[row][col] == '#')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }

                        Console.Write(MapDisplay[row][col] + " ");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (row != MapDisplay.Count - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        public static void Update(ConsoleKey key)
        {
            int newRow = pRow;
            int newCol = pCol;

            switch (key)
            {
                case ConsoleKey.W: newRow--; break;
                case ConsoleKey.S: newRow++; break;
                case ConsoleKey.A: newCol--; break;
                case ConsoleKey.D: newCol++; break;
                default: return;
            }

            if (MapDisplay[newRow][newCol] != '#')
            {
                Console.SetCursorPosition(pCol * 2, pRow);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(". ");

                pRow = newRow;
                pCol = newCol;

                Console.SetCursorPosition(pCol * 2, pRow);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@ ");
            }
        }

        static void GenerateEnemies(int howmuch)
        {
            ePos.Clear();

            for (int i = 0; i < howmuch; i++)
            {
                ePos.Add((Random.Shared.Next(1, Rows - 1), Random.Shared.Next(1, Cols - 1)));
            }
        }
    }
    class BattleDisplay
    {
        public readonly Character You;
        public readonly Character Target;

        readonly int Rows;
        readonly int Cols;

        public BattleDisplay(Character you, Character target)
        {
            You = you;
            Target = target;

            Rows = Console.WindowHeight;
            Cols = Console.WindowWidth;
        }

        public void Draw()
        {
            Console.Clear();

            for (int i = 0; i < ArtAssets.Battle.Length; i++)
            {
                Console.SetCursorPosition((Cols / 2 - ArtAssets.Battle[0].Length / 2) + 2, (Rows / 4) + i - (ArtAssets.Battle.Length / 2));
                Console.Write(ArtAssets.Battle[i]);
            }

            DrawCharacter(You, ArtAssets.KnightIdle, Cols / 3);

            DrawCharacter(Target, ArtAssets.MageIdle, Cols / 1.5);
        }

        public decimal Attack(Character character)
        {
            if (character is Character && (character == You || character == Target))
            {
                if (character == You)
                {
                    //          _,.                      
                    //        ,` -.)                     
                    //       ( _/-\\-..__,            
                    //      /,| `--._,-+>|            
                    //      \_|  |`-._./||          
                    //        |   `-,  / |         
                    //        |      ||  |        
                    //         `r-._ || /   
                    //     __,--<_     )`>,--. 
                    //   .`   \   `---'   \   }
                    //  /     :            ?  |   
                    // : ._. /            ;`.-: 
                    // /    |           .`   '  
                    // |    ;          /   ./ 
                    // \,.-->.._.__--`:-.+:| 
                    //  (  /   `-._--(uuu)+----------------------------., 
                    //  `--._______.(^^^)-+----------------------------` 
                    //      |      `"'"" /
                    //      :           "

                } else
                {
                    // show Target attack
                }
            }
                return 0.0m;
        }

        void DrawCharacter(Character character, string[] str, double col)
        {
            col = (col - str[0].Length / 2) + 2; // It is not centerd, either 1 nor 2 works and puts it in the middle

            Console.SetCursorPosition((int)col, Rows - str.Length - 4);
            Console.Write(@$"Name: {character.Name + new string(' ', 27 - character.Name!.Length)}");
            Console.SetCursorPosition((int)col, Rows - str.Length - 3);
            Console.Write(@"=================================");
            Console.SetCursorPosition((int)col, Rows - str.Length - 2);
            Console.Write(@$"HP: {character.HP}                Power: {character.Power:0.00}");

            for (int i = 0; i < str.Length; i++)
            {
                Console.SetCursorPosition((int)col, Rows + i - str.Length);
                Console.Write(str[i]);
            }

            //Previous Design
            //Console.SetCursorPosition((int)(Cols / 3 - ArtAssets.KnightIdle[0].Length / 2) + 2, Rows - ArtAssets.KnightIdle.Length - 4);
            //Console.Write(@$"Name: {You.Name + new string(' ', 27 - You.Name!.Length)}");
            //Console.SetCursorPosition((int)(Cols / 3 - ArtAssets.KnightIdle[0].Length / 2) + 2, Rows - ArtAssets.KnightIdle.Length - 3);
            //Console.Write(@"=================================");
            //Console.SetCursorPosition((int)(Cols / 3 - ArtAssets.KnightIdle[0].Length / 2) + 2, Rows - ArtAssets.KnightIdle.Length - 2);
            //Console.Write(@$"HP: {You.HP}                Power: {You.Power:0.00}");

            //for (int i = 0; i < ArtAssets.KnightIdle.Length; i++) // For Knight
            //{
            //    Console.SetCursorPosition((int)(Cols / 3 - ArtAssets.KnightIdle[0].Length / 2) + 2, Rows + i - ArtAssets.KnightIdle.Length);
            //    Console.Write(ArtAssets.KnightIdle[i]);
            //}
        }
    }
}