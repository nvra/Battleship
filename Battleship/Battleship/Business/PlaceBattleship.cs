using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Enums;

namespace Battleship.Business
{
    public class PlaceBattleship
    {
        int battleshipLen = 0;
        char placementType = ' ';
        string startPosition = "";
        string input = "";
        bool success = true;
        ValidateUserInputs ui;
        ExitApplication ea;

        readonly int rep = 5; // number of retrys allowed when user allowed an invalid input 

        /* places the battleship on board by getting the required input from the user.
         * inputs required are Orientation - Horizontal(H)/Vertical(V)
         * length of the battleship should be between 1 and 5
         * start position of the battleship. A coordinate from the grid. Should be XY.
         * returns length of the battleship
         * */
        public int PlaceBattleShip()
        {
            try
            {
                ui = new ValidateUserInputs();
                ea = new ExitApplication();

                // gets the orientation
                GetBattleshipPlacementType();

                // gets the battleship length
                GetBattleshipLength();

                // get the start position XY coordinates
                GetStartPosition();

                // places the battleship on board with the above 3 inputs
                BoardBattleship();

                return battleshipLen;
            }
            catch
            {
                throw;
            }
        }

        // boards the Battleship on board with the 3 user inputs
        public void BoardBattleship()
        {
            try
            {
                GetCoordinates co = new GetCoordinates();
                int x = 0;
                int y = 0;

                // get the X and Y coordinates from the start position
                co.GetXY(startPosition, out x, out y);

                if (placementType == 'H') // if horizontal orientation
                {
                    // places the battleship horizontally 
                    for (int col = y; col < y + battleshipLen; col++)
                    {
                        DisplayGrid.ownGrid[x, col] = 'B';
                    }
                }
                else if (placementType == 'V') // if vertical orientation
                {
                    // places the battleship vertically 
                    for (int row = x; row < x + battleshipLen; row++)
                    {
                        DisplayGrid.ownGrid[row, y] = 'B';
                    }
                }
                Console.WriteLine("Battleship placed Successfully.");
            }
            catch
            {
                throw;
            }
        }

        #region UserInput

        // gets the Battleship Length from the user and validates it
        // Expects a number between 1-5
        // retrys for 5 times if invalid input is provided
        public void GetBattleshipLength()
        {
            try
            {
                int loop = 0;
                do
                {
                    // gets the input from user
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Enter the length of Battleship. Must be a number of length 1 - 5.");
                    input = Console.ReadLine().ToString();

                    // validate if the entered input is valid
                    success = ui.ValidateUserInputLength(input, out battleshipLen);

                    if (!success)
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("Invalid Input.");
                    }
                    else
                    {
                        break;
                    }

                    loop++;

                } while (loop < rep); // repeat to get input if invalid input

                if (!success && loop == rep)
                {
                    // exits after maximum allowed retrys
                    ea.ExitMaxRetry();
                }
            }
            catch
            {
                throw;
            }
        }
        
        // gets the Battleship Orientation from the user and validates it
        // expects H/V
        // retrys for 5 times if invalid input is provided
        public void GetBattleshipPlacementType()
        {
            try
            {
                int loop = 0;
                do
                {
                    // gets input from the user
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("How do you want to place the Battleship? Enter 'H' for Horizontal and 'V' for Vertical.");
                    input = Console.ReadLine().ToString().ToUpper();

                    // validates the input
                    success = ui.ValidateUserInputType(input);

                    if (!success)
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("Invalid Input.");
                    }
                    else
                    {
                        placementType = Convert.ToChar(input);
                        break;
                    }

                    loop++;

                } while (loop < rep); // repeat to get input if invalid input

                if (!success && loop == rep)
                {
                    // exits after maximum allowed retrys
                    ea.ExitMaxRetry();
                }
            }
            catch
            {
                throw;
            }
        }

        // gets the Start position to place the Battleship on board from the user and validates it
        // expects XY coordinates X should be between A-J and Y should be between 1-10
        // retrys for 5 times if invalid input is provided
        public void GetStartPosition()
        {
            try
            {
                int loop = 0;
                int outloop = 0;
                do
                {
                    do
                    {
                        // get the input from the user
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("Enter the Start Position of the Battleship. Eg. B3 - B is the row name and 3 is the col number");
                        input = Console.ReadLine().ToString().ToUpper();

                        // validates the input if its in correct format XY and also a valid position from the grid
                        success = ui.ValidatePlacementInput(input);

                        if (!success)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("Invalid Input.");
                        }
                        else
                        {
                            startPosition = input;
                            break;
                        }

                        loop++;

                    } while (loop < rep); // repeat in case invalid input 

                    if (!success && loop == rep)
                    {
                        // exits after maximum allowed retrys
                        ea.ExitMaxRetry();
                    }

                    // if the entered input is a valid position from the grid
                    if (success) 
                    {
                        // validate if the battleship can be placed at that position i.e. if it fits from there
                        success = ui.ValidatePlacement(startPosition, placementType, battleshipLen);

                        if (!success)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("Length is not sufficient at that position. Try again");
                        }
                        else
                        {
                            break;
                        }

                        outloop++;
                    }
                } while (outloop < rep); // repeat if its not fit to get a new position

                if (!success && outloop == rep)
                {
                    // exits after maximum allowed retrys
                    ea.ExitMaxRetry();
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion UserInput
    }
}
