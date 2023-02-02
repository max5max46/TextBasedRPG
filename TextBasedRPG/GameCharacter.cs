using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class GameCharacter
    {
        public Random RNG = new Random();
        public int x;
        public int y;
        public int tempX;
        public int tempY;
        public int health;
        public bool hitEnemy;
    }
}
