using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Program
    {
        static bool gameLoop = true;

        public static int offsetX = 2;
        public static int offsetY = 1;


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Map.Draw();
            while (gameLoop)
            {
                Player.Draw();
                Player.Update();
            }
        }
    }
}
