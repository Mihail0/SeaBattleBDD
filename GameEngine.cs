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
        /// Puts the ship at the target location.
        /// </summary>
        /// <param name="map">Map where the ship will be placed</param>
        /// <param name="x">Position along the x-axis</param>
        /// <param name="y">Position along the y-axis</param>
        /// <param name="length">Length of the ship</param>
        /// <param name="direction">Direction of the ship</param>
        public void putShip(bool[,] map, byte x, byte y, byte length, bool direction)
        {
            //todo add exception handler
            byte _X = x;
            byte _Y = y;
            for (byte i = 0; i < length; i++)
            {
                map[_X, _Y] = Globals.SHIP;
                if (!direction) _X++; else _Y++;
            }
        }

        /// <summary>
        /// Puts the shot at the target location.
        /// </summary>
        /// <param name="map">Map where the shot will be placed</param>
        /// <param name="x">Position along the x-axis</param>
        /// <param name="y">Position along the y-axis</param>
        public void putShot(bool[,] map, byte x, byte y)
        {
            //outdated method
            map[x, y] = Globals.SHOT;
        }

        /// <summary>
        /// Puts the shot at the target location and explodes area if needed.
        /// </summary>
        /// <param name="shotsMap">Map where the shot will be placed</param>
        /// <param name="shipsMap">Map contains all ships</param>
        /// <param name="x">Position along the x-axis</param>
        /// <param name="y">Position along the y-axis</param>
        /// <returns>Result code</returns>
        public byte putShot(bool[,] shotsMap, bool[,] shipsMap, byte x, byte y)
        {
            //todo add exception handler
            if (shotsMap[x, y] == Globals.SHOT) return Globals.REZMISS;
            shotsMap[x, y] = Globals.SHOT;
            //No ships found
            if (shipsMap[x, y] != Globals.SHIP) return Globals.REZMISS;
            byte X = x;
            byte Y = y;
            //Moving to top left corner of the ship
            while (true)
            {
                if (X == 0) break;
                if (shipsMap[X - 1, Y] != Globals.SHIP) break;
                X--;
            }
            while (true)
            {
                if (Y == 0) break;
                if (shipsMap[X, Y - 1] != Globals.SHIP) break;
                Y--;
            }
            bool direction = Globals.HRZT;
            if (Y < Globals.MAPSIZE - 1)
                if (shipsMap[X, Y + 1] == Globals.SHIP) direction = Globals.VERT;
            byte Z = 0;
            if (!direction) Z = X; else Z = Y;
            bool explosion = true;
            while (true)
            {
                if ((!direction) && (!(X + 1 < Globals.MAPSIZE))) break;
                if (direction && (!(Y + 1 < Globals.MAPSIZE))) break;
                if (shipsMap[X, Y] != Globals.SHIP) break;
                if (shotsMap[X, Y] != Globals.SHOT) explosion = false;
                if (!direction) X++; else Y++;
            }
            if (explosion)
            {
                if (!direction)
                {
                    for (byte i = Z; i < X; i++)
                    {
                        explode(shotsMap, Z, Y);
                    }
                }
                else
                {
                    for (byte i = Z; i < Y; i++)
                    {
                        explode(shotsMap, X, Z);
                    }
                }
                return Globals.REZKILL;
            }
            return Globals.REZHIT;
        }

        /// <summary>
        /// Builds the result map that player can see.
        /// </summary>
        /// <param name="shipsMap">Map that contains all ships</param>
        /// <param name="shotsMap">Map that contains all shots</param>
        /// <returns>Result map</returns>
        public char[,] makeResult(bool[,] shipsMap, bool[,] shotsMap)
        {
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
                            if (!shipsMap[i, j])
                                result[i, j] = Globals.MISS;
                            else
                                result[i, j] = Globals.DEAD;
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
