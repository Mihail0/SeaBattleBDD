using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SeaBattleBDD
{
    class Program
    {
        [DllImport("msvcrt")]
        static extern int _getch();

        static void Main(string[] args)
        {
            //todo refactor this code
            //Initialization
            GameEngine gameEngine = new GameEngine();
            bool[,] shipsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            bool[,] shotsMap = new bool[Globals.MAPSIZE, Globals.MAPSIZE];
            char[,] resltMap;
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    shipsMap[i, j] = Globals.EMPTY;
                    shotsMap[i, j] = Globals.EMPTY;
                }
            }
            byte attempts = 0;
            byte gamestate = 0;
            byte shipscount = 5;
            gameEngine.putShip(shipsMap, 5, 2, 1, Globals.HRZT);
            gameEngine.putShip(shipsMap, 9, 0, 4, Globals.VERT);
            gameEngine.putShip(shipsMap, 2, 5, 3, Globals.VERT);
            gameEngine.putShip(shipsMap, 6, 6, 2, Globals.HRZT);
            gameEngine.putShip(shipsMap, 4, 8, 5, Globals.HRZT);
            string message = "The game is on!";
            do {
                Console.Clear();
                Console.WriteLine(message);
                Console.WriteLine();
                resltMap = gameEngine.makeResult(shipsMap, shotsMap);
                gameEngine.print(resltMap);
                if (gamestate == Globals.REZWIN)
                {
                    Console.WriteLine();
                    Console.WriteLine("Attempts: {0}", attempts);
                    Console.WriteLine();
                    _getch();
                    break;
                }
                Console.WriteLine();
                Console.Write("Enter fire coordinates: ");
                Globals.fflush();
                byte y = Globals.Read();
                byte x = Globals.Read();
                gamestate = gameEngine.putShot(shotsMap, shipsMap, x, y);
                attempts++;
                if (gamestate == Globals.REZKILL) shipscount--;
                if (shipscount == 0) gamestate = Globals.REZWIN;
                switch (gamestate) {
                    case Globals.REZMISS:
                        message = "You have missed the ship.";
                        break;
                    case Globals.REZHIT:
                        message = "You have hit the ship!";
                        break;
                    case Globals.REZKILL:
                        message = "You have destroyed the ship!";
                        break;
                    case Globals.REZWIN:
                        message = "Congratulations! You Won!";
                        break;
                }
            } while (true);
        }
    }
}
