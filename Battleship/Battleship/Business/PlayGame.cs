using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Business
{
    public class PlayGame
    {
        readonly int rep = 5;
        bool success = false;
        string input = string.Empty;
        ValidateUserInputs ui;
        string firingPosition = string.Empty;
        string message = string.Empty;

        static int hitCount = 0; // to track the hit count
        static bool IsSunk = false; // to track if game is finished

        // it takes the input firing shot from the user and diplays hit/miss and continue till game is finished
        public void play(int battleshiplen)
        {
            try
            {
                ui = new ValidateUserInputs();
                int loop = 0;
                bool track = false;

                DisplayGrid dg = new DisplayGrid();

                do
                {
                    // get the firingshot
                    GetFiringShot();

                    // process the firing shot
                    track = ProcessFiringShot();

                    // show the grids with updated firing grid with Hit or Miss
                    dg.ShowBoards();

                    Console.WriteLine(message);
                    if (track) // if its a hit
                    {
                        // check if game finished
                        if (TrackHitShot(battleshiplen))
                        {
                            Console.WriteLine(message);
                            Console.WriteLine("Game Over !!!");

                            IsSunk = true; // game finished
                        }
                    }

                    loop++;

                } while (!IsSunk); // repeat till game is finished
            }
            catch
            {
                throw;
            }
        }

        // gets the firing shot from the user and validates if its a valid position on the grid
        public void GetFiringShot()
        {
            try
            {
                int loop = 0;

                do
                {
                    // get firing position from the user
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Enter Firing Position. Eg. B3 - B is the row name and 3 is the col number");
                    input = Console.ReadLine().ToString().ToUpper();

                    // check if the input is a valid position from the grid
                    success = ui.ValidatePlacementInput(input);

                    if (!success)
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("Invalid Input.");
                    }
                    else
                    {
                        firingPosition = input;
                        break;
                    }

                    loop++;

                } while (loop < rep); // repeat till user enters a valid position for rep times

                if (!success && loop == rep)
                {
                    // exit application after maximum retrys
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Maximum retry exceeded. Exiting... Start a new game.");

                    Environment.Exit(1);
                }
            }
            catch
            {
                throw;
            }
        }

        // process the firing shot and retuns a hit or miss.
        // updates the firing grid with H/M accordingly
        public bool ProcessFiringShot()
        {
            try
            {
                GetCoordinates co = new GetCoordinates();
                int x = 0;
                int y = 0;

                // get the X and Y coordinates
                co.GetXY(firingPosition, out x, out y);

                if (DisplayGrid.firingGrid[x, y] != '0') // check if that coordinate is already fired earlier.
                {
                    message = "Already shot at this position";
                    return false;
                }
                else
                {
                    // check if the battleship is placed at that position
                    if (DisplayGrid.ownGrid[x, y] == 'B') // if its a hit update firing grid position with h
                    {
                        message = "It's a HIT";
                        DisplayGrid.firingGrid[x, y] = 'H';
                        hitCount++;

                        return true;
                    }
                    else // if its a miss update firing grid position with m
                    {
                        message = "It's a MISS";
                        DisplayGrid.firingGrid[x, y] = 'M';

                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        // tracks if the game is finished and returns true if game is finished
        public bool TrackHitShot(int battleshiplen)
        {
            try
            {
                // if number of hit counts is equal to the battleship length, game is finished
                if (hitCount == battleshiplen)
                {
                    message = "Battleship Sunk. Game won !!";
                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
