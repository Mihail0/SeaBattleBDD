using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattleBDD
{
    public static class Globals
    {
        private static readonly Random random = new Random();

        public const byte MAPSIZE = 10;
        public const byte EXPLOSIONRADIUS = 1;
        public const bool EMPTY = false;
        public const bool SHIP = true;
        public const bool SHOT = true;
        public const bool HRZT = false;
        public const bool VERT = true;

        public const byte REZMISS = 0;
        public const byte REZHIT = 1;
        public const byte REZKILL = 2;

        public const char WATER = '*';
        public const char MISS = 'O';
        public const char DEAD = 'X';

        public static byte getRandom(byte min, byte max)
        {
            return Convert.ToByte(random.Next(min, max));
        }
    }
}
