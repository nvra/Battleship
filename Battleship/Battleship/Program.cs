using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Business;
using Battleship.Enums;

namespace Battleship
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to BATTLESHIP");
                Console.WriteLine(Environment.NewLine);

                DisplayGrid dg = new DisplayGrid();

                /* display empty boards */
                dg.ShowBoards();

                PlaceBattleship pb = new PlaceBattleship();
                /* place the battleship on board by getting input from the user */
                int battleshiplen = pb.PlaceBattleShip();

                /* display the boards with battleship on board */
                dg.ShowBoards();

                PlayGame pg = new PlayGame();

                /* Play the game by getting the firing shot from the user */
                pg.play(battleshiplen);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                /* exit the application once game finished */
                ExitApplication ea = new ExitApplication();
                ea.ExitApp();
            }
        }
    }
}
