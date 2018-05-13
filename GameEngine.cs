using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaBattleBDD
{
    /// <summary>
    /// A game engine.
    /// </summary>
    class GameEngine
    {
        /// <summary>
        /// Puts the ship at the target location.
        /// </summary>
        /// <param name="map">Map where the ship will be placed</param>
        /// <param name="x">Position along the x-axis</param>
        /// <param name="y">Position along the y-axis</param>
        public void putShip(bool[,] map, byte x, byte y)
        {
            //todo refactor this code
            map[x, y] = Globals.SHIP;
        }

        /// <summary>
        /// Puts the shot at the target location.
        /// </summary>
        /// <param name="map">Map where the shot will be placed</param>
        /// <param name="x">Position along the x-axis</param>
        /// <param name="y">Position along the y-axis</param>
        public void putShot(bool[,] map, byte x, byte y)
        {
            //todo refactor this code
            map[x, y] = Globals.SHOT;
        }

        /// <summary>
        /// Builds the result map that player can see.
        /// </summary>
        /// <param name="shipsMap">Map that contains all ships</param>
        /// <param name="shotsMap">Map that contains all shots</param>
        /// <returns>Result map</returns>
        public char[,] makeResult(bool[,] shipsMap, bool[,] shotsMap)
        {
            //todo refactor this code
            char[,] result = new char[Globals.MAPSIZE, Globals.MAPSIZE];
            for (byte i = 0; i < Globals.MAPSIZE; i++)
            {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    switch (shotsMap[i, j])
                    {
                        case Globals.EMPTY:
                            result[i, j] = Globals.WATER;
                            break;
                        case Globals.SHOT:
                            result[i, j] = Globals.MISS;
                            break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Prints the result map.
        /// </summary>
        /// <param name="result">Result map</param>
        public void print(char[,] result)
        {
            for (byte i = 0; i < Globals.MAPSIZE; i++) {
                for (byte j = 0; j < Globals.MAPSIZE; j++)
                {
                    Console.Write(result[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
