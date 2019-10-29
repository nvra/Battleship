using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Enums;

namespace Battleship.Business
{
    public class DisplayGrid
    {
        public static char[,] ownGrid;
        public static char[,] firingGrid;

        /* constructor to initialize the empty grids when game starts */
        static DisplayGrid()
        {
            ownGrid = new char[11, 11];
            firingGrid = new char[11, 11];

            char c = ' ';
            for (int row = 0; row < 11; row++)
            {
                for (int col = 0; col < 11; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        c = ' ';
                    }
                    else if (row == 0)
                    {
                        if (col == 10)
                            c = 'X'; // replacing column 10 with X to maintain a single char column name
                        else
                            c = Convert.ToChar(col.ToString());
                    }
                    else if (col == 0)
                    {
                        c = Convert.ToChar(Enum.GetName(typeof(GridRow), row));
                    }
                    else
                    {
                        c = '0';
                    }

                    ownGrid[row, col] = c;
                    firingGrid[row, col] = c;
                }
            }
        }

        /* method to display both boards at any point of the game */
        public void ShowBoards()
        {
            try
            {
                Console.WriteLine("     Placement Board:                           Firing Board:");
                Console.WriteLine("--------------------------------------------------------------");
                for (int row = 0; row < 11; row++)
                {
                    // displaying placement grid row by row
                    for (int ownCol = 0; ownCol < 11; ownCol++)
                    {
                        Console.Write(ownGrid[row, ownCol] + " ");
                        if (ownCol == 0)
                        {
                            Console.Write(" ");
                        }
                    }
                    // display firing grid row by row
                    Console.Write("                ");
                    for (int firingCol = 0; firingCol < 11; firingCol++)
                    {
                        Console.Write(firingGrid[row, firingCol] + " ");
                        if (firingCol == 0)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine(Environment.NewLine);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
