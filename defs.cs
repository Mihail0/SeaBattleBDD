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
        public const bool EMPTY = false;
        public const bool SHIP = true;
        public const bool SHOT = true;

        public const char WATER = '*';
        public const char MISS = 'O';

        public static byte getRandom(byte min, byte max)
        {
            return Convert.ToByte(random.Next(min, max));
        }
    }
}
