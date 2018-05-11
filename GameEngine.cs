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
            map[0, 0] = Globals.SHIP;
        }
    }
}
