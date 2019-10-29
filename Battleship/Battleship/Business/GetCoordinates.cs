using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Enums;

namespace Battleship.Business
{
    public class GetCoordinates
    {
        // Get the X and Y coordinates from any position on the grid
        // return bool
        // parameters input = any position on the grid
        // out parameters X and Y with the coordinates
        public bool GetXY(string input, out int x, out int y)
        {
            try
            {
                x = 0;
                y = 0;
                input = input.ToUpper();
                // replacing column 10 with X to maintain a single char column name
                input = input[0] + input.Substring(1, input.Length - 1).Replace("10", "X");

                // any position on grid is only 2 char length XY, so return false if length > 2
                if(input.Length > 2)
                {
                    return false;
                }

                char[] temp = input.ToCharArray();

                // check if x exists in the Enum GridRow[A-J]
                bool Exists = Enum.TryParse(temp[0].ToString(), out GridRow row);

                if (Exists)
                {
                    x = (int)row;

                    if (temp[1] == 'X')
                    {
                        y = 10;
                    }
                    else
                    {
                        // check if y entered is an integer
                        Exists = Int32.TryParse(temp[1].ToString(), out y);

                        if(Exists)
                        {
                            // y should be between 1-10
                            if(y >0 && y<=10)
                            {
                                Exists = true;
                            }
                            else
                            {
                                Exists = false;
                            }
                        }
                    }
                }

                return Exists;
            }
            catch
            {
                throw;
            }
        }
    }
}
