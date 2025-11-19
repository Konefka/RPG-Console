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

        public static readonly Dictionary<string, string> InGameMessages = new Dictionary<string, string>()
        {
            { "Start", "Press any button to start" }
        };

    }
    
    static class General
    {
        public static void ShowMessage(string key, int row, int col)
        {
            if (!ArtAssets.InGameMessages.ContainsKey(key)) return;

            Console.SetCursorPosition(col - (ArtAssets.InGameMessages[key].Length / 2), row);
            Console.Write(ArtAssets.InGameMessages[key]);
        }
    }

    static class Menu
    {
        static int Rows;
        static int Cols;
        static List<(int row, int col)> sPos = new List<(int, int)>();

        public static void Draw()
        {
            if (!sPos.Any()) GenerateStars(Console.WindowHeight, Console.WindowWidth);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var s in sPos)
            {
                Console.SetCursorPosition(s.col, s.row);
                Console.Write('*');
            }

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < ArtAssets.Start.Length; i++)
            {
                Console.SetCursorPosition((Cols / 2 - ArtAssets.Start[0].Length / 2) + 2, (Rows / 2 - 1) + i - (ArtAssets.Start.Length / 2));
                Console.Write(ArtAssets.Start[i]);
            }

            General.ShowMessage("Start", Rows - 1, Cols / 2);
        }
        public static void AnimateStars(CancellationToken token)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor= ConsoleColor.Yellow;

            while (!token.IsCancellationRequested)
            {
                int star = Random.Shared.Next(sPos.Count);
                Console.SetCursorPosition(sPos[star].col, sPos[star].row);
                Console.Write(Random.Shared.Next(2) == 0 ? ' ' : '*');

                Thread.Sleep(75);
            }
        }
        public static void GenerateStars(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            sPos.Clear();

            for (int i = 0; i < Rows * 2; i++)
            {
                sPos.Add((Random.Shared.Next(1, Rows - 1), Random.Shared.Next(1, Cols - 1)));
            }
        }
    }
    static class Map
    {
        static int Rows = 30;
        static int Cols = 120;
        static int pRow;
        static int pCol;
        public static List<(int row, int col)> ePos = new List<(int, int)>();
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
            if (!MapDisplay.Any()) Generate(Console.WindowHeight, Console.WindowWidth);

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
                        if (MapDisplay[row][col] == '#') Console.ForegroundColor = ConsoleColor.Blue;

                        Console.Write(MapDisplay[row][col] + " ");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (row != MapDisplay.Count - 1) Console.WriteLine();
            }
        }
        public static string Update(ConsoleKey key, bool IsOverride = false)
        {
            int newRow = pRow;
            int newCol = pCol;

            switch (key)
            {
                case ConsoleKey.W: newRow--; break;
                case ConsoleKey.S: newRow++; break;
                case ConsoleKey.A: newCol--; break;
                case ConsoleKey.D: newCol++; break;
                default: return "wall";
            }

            if (!IsOverride)
            {
                if (ePos.Contains((newRow, newCol))) return "battle";
            }
            else
            {
                ePos.Remove((newRow, newCol));
            }

            if (MapDisplay[newRow][newCol] == '.')
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

            if (!ePos.Any())
            {
                return "win";
            }

            return "move";
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
            Console.ForegroundColor= ConsoleColor.White;

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