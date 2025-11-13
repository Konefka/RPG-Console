using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
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

            int center = Rows / 2 - 1;

            for (int row = 0; row < MenuDisplay.Count; row++)
            {
                for (int col = 0; col < MenuDisplay[0].Count; col++)
                {
                    if (row >= center - 5 && row <= center + 5 && col == Cols / 2 - 44)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        switch (row - center)
                        {
                            case -5: Console.Write(@"  ++%%%%%%##::  ++%%%%%%%%%%%%%%##     ++%%%%        %%%%%%%%%%##,,   ++%%%%%%%%%%%%%%##"); break;
                            case -4: Console.Write(@"**%%##++++%%%%  ::++++++%%##++++**     %%##%%::      %%%%++++++%%%%,, ::++++++%%##++++**"); break;
                            case -3: Console.Write(@"##%%..    ..,,          %%++         ,,%%::%%++      %%##      **%%**         %%++      "); break;
                            case -2: Console.Write(@"++%%,,                  %%++         **%%..++%%      %%##      ::%%++         %%++      "); break;
                            case -1: Console.Write(@"::%%%%++,,              %%++         ####  **%%,,    %%##      ::%%**         %%++      "); break;
                            case 0: Console.Write(@"  ,,##%%%%++..          %%++       ..%%++  ,,%%**    %%%%++++++%%%%..         %%++      "); break;
                            case 1: Console.Write(@"      ::##%%##          %%++       ::%%++++++%%##    %%%%%%%%%%%%,,           %%++      "); break;
                            case 2: Console.Write(@"          ++%%,,        %%++       ++%%%%%%%%%%%%    %%##    ++%%,,           %%++      "); break;
                            case 3: Console.Write(@"..        ++%%::        %%++       %%##      ::%%::  %%##    ::%%++           %%++      "); break;
                            case 4: Console.Write(@"%%##++++++%%%%          %%++     ,,%%**        %%++  %%##      ##%%,,         %%++      "); break;
                            case 5: Console.Write(@"++##%%%%%%##,,          %%++     ++%%,,        ##%%  %%##      ::%%++         %%++      "); break;
                        }

                        col += 89;
                    }
                    else if (sPos.Contains((row, col)))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
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

    class Battle
    {
        readonly Character You;
        readonly Character Target;

        public Battle(Character you, Character target)
        {
            You = you;
            Target = target;
        }

        public void DisplayBattle()
        {
            int rows = Console.WindowHeight;
            int cols = Console.WindowWidth;

            // %%%%%%%%%##,,          ++%%%%    ++%%%%%%%%%%%%%%## ++%%%%%%%%%%%%%%##  %%++              ++%%%%%%%%%%%%##
            // %%%%++++++%%%%         %%##%%::  ::++++++%%##++++** ::++++++%%##++++**  %%++              %%**++++++++++::
            // %%##      **%%,      ,,%%::%%++          %%++               %%++        %%++              %%++
            // %%##      ::##       **%%..++%%          %%++               %%++        %%++              %%++
            // %%%%++++++**..       ####  **%%,,        %%++               %%++        %%++              %%**++++++++,,
            // %%%%%%%%%%##::     ..%%++  ,,%%**        %%++               %%++        %%++              ++%%%%%%%%%%##
            // %%##      %%%**    ::%%++++++%%##        %%++               %%++        %%++              %%++
            // %%##      ::%%++   ++%%%%%%%%%%%%        %%++               %%++        %%++              %%++
            // %%##      ::%%**   %%##      ::%%::      ##==               %%++        %%++              %%++
            // %%**++++++%%%..  ,,%%**        %%++      ##==               %%++        %%**++++++++++::  %%**++++++++++::
            // %%%%%%%%%%%%:`   ++%%,,        ##%%      ##==               %%++        ++%%%%%%%%%%%%##  ++%%%%%%%%%%%%##

            //   ++%%%%%%##::  ++%%%%%%%%%%%%%%##     ++%%%%        %%%%%%%%%%##,,   ++%%%%%%%%%%%%%%##
            // **%%##++++%%%%  ::++++++%%##++++**     %%##%%::      %%%%++++++%%%%,, ::++++++%%##++++**
            // ##%%..    ..,,          %%++         ,,%%::%%++      %%##      **%%**         %%++      
            // ++%%,,                  %%++         **%%..++%%      %%##      ::%%++         %%++      
            // ::%%%%++,,              %%++         ####  **%%,,    %%##      ::%%**         %%++      
            //   ,,##%%%%++..          %%++       ..%%++  ,,%%**    %%%%++++++%%%%..         %%++      
            //       ::##%%##          %%++       ::%%++++++%%##    %%%%%%%%%%%%,,           %%++      
            //           ++%%,,        %%++       ++%%%%%%%%%%%%    %%##    ++%%,,           %%++      
            // ..        ++%%::        %%++       %%##      ::%%::  %%##    ::%%++           %%++      
            // %%##++++++%%%%          %%++     ,,%%**        %%++  %%##      ##%%,,         %%++      
            // ++##%%%%%%##,,          %%++     ++%%,,        ##%%  %%##      ::%%++         %%++      

            //        _,.                      
            //      ,` -.)                    ,
            //     ( _/-\\-..__,            ,'|
            //    /,| `--._,-+>|           /  /
            //    \_|  |`-._./||          /  / 
            //      |   `-,  / |         /  /  
            //      |      ||  |        /  /   
            //       `r-._ || /   __   /  /    
            //   __,--<_     )`-/   `./  /     
            // .`   \   `---'   \    /  /      
            // |     |           ;_./  /       
            // :     /           : /  /        
            //  \_/'  \         .|/  /         
            //   |     |   _,*-' /  /          
            //   |     ,*``   (\/  /._         
            //    \,.-->.._    \X-=/^`         
            //    (  /     `-._//^:            
            //     `Y-.______(__}/:            
            //      |       {__)  :            
            //      |       ``   "             

            //                      ,-----.    
            //                     /      |    
            //               ____,'       |__  
            //             <   -'         :   >
            //              `-.__..--'``-,_\_` 
            //                 |o/ ` o,.)_`>   
            //                 :/ `     ||/)   
            //                 (_.).__,-` |    
            //                 /( `.``   `|    
            //                 |'`-.)  `  ;    
            // ,-_-..____     /|     `  /  `:. 
            // |'-.__\\  ``-./ |  `    : , `. :
            // : `\  `\\  \ :  (   `  /|    | |
            //  \` \   \\   |  | `   : :    .\:
            //   \ `\_  ))  :  ;     | |    );|
            //  (`-.-'\ ||  |\ \   ` ; ;     |:
            //   \-_   `;;._   ( `  / /_     ||
            //    `-.-.// ,'`-._\__/,'(      ;|
            //       \:: :     /    `   ,   / :
            //        || |    (     ,' /   /  |
        }

        public decimal Attack(Character character)
        {
            return 0.0m;
        }
    }
}