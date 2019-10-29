using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Enums;

namespace Battleship.Business
{
    public class ValidateUserInputs
    {
        bool success = false;

        #region Validations

        /* Validates if the Battleship Length entered by the User
         * it should be a number between 1-5
         * returns true if a valid number else returns false
         * */
        public bool ValidateUserInputLength(string input, out int battleshipLen)
        {
            try
            {
                // check if input a number
                success = int.TryParse(input, out battleshipLen);

                // check if input is between 1 and 5
                if (success && battleshipLen > 0 && battleshipLen <= 5)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

                return success;
            }
            catch
            {
                throw;
            }
        }

        /* Validates the Battleship Orientation entered by the User
         * it should be either 'H' or 'V'
         * returns true if a valid orientation else returns false
         * */
        public bool ValidateUserInputType(string input)
        {
            try
            {
                // check if input entered is H/V
                if (input == "H" || input == "V")
                {
                    success = true;
                }
                else
                    success = false;

                return success;
            }
            catch
            {
                throw;
            }
        }

        /* Validates the Start position entered by the User
         * it should be XY where X is [A-J] and y is [1-10]
         * returns true if a valid position on the grid else returns false
         * */
        public bool ValidatePlacementInput(string input)
        {
            try
            {
                input = input.ToUpper();
                // replacing column 10 with X to maintain a single char column name
                input = input[0] + input.Substring(1, input.Length - 1).Replace("10", "X");

                // any position on grid is only 2 char length XY, so return false if length > 2
                if (input.Length > 2)
                {
                    return false;
                }
                char[] temp = input.ToCharArray();
                int col = 0;

                // check if X is between A and J, defined in enum 
                success = Enum.IsDefined(typeof(GridRow), temp[0].ToString());

                if (success && temp[1] != 'X')
                {
                    // check if Y is a number
                    success = int.TryParse(temp[1].ToString(), out col);

                    // check if Y is between 1 and 10
                    if (success && col > 0 && col <= 10)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }

                return success;
            }
            catch
            {
                throw;
            }
        }

        /* Validates if the Battleship can be placed at the position entered by the user
         * it should fit from the start position towards right or bottom. shouldn't exceed the grid
         * returns true if a valid position else returns false
         * */
        public bool ValidatePlacement(string startPosition, char placementType, int battleshipLen)
        {
            try
            {
                startPosition = startPosition.ToUpper();
                // replacing column 10 with X to maintain a single char column name
                startPosition = startPosition[0] + startPosition.Substring(1, startPosition.Length - 1).Replace("10", "X");

                // any position on grid is only 2 char length XY, so return false if length > 2
                if (startPosition.Length > 2)
                {
                    return false;
                }

                GetCoordinates co = new GetCoordinates();
                int x = 0;
                int y = 0;

                // get the X and Y coordinates
                co.GetXY(startPosition, out x, out y);

                int pos = 0;

                if (placementType == 'H') // if orientation is horizontal
                {
                    pos = y;
                }
                else if (placementType == 'V') // if orientation is vertical
                {
                    pos = x;
                }

                if (pos + battleshipLen <= 11) // check if the battleship is not exceeding the grid length
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

                return success;
            }
            catch
            {
                throw;
            }
        }

        #endregion Validations
    }
}
