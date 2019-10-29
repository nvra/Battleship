using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Business
{
    public class ExitApplication
    {
        // Exit application after Maximum retrys allowed
        public void ExitMaxRetry()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Maximum retry exceeded. Exiting... Start a new game.");

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            Environment.Exit(1);
        }

        // Exit Application when game is finished
        public void ExitApp()
        {
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
