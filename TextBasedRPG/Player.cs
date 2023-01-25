using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player
    {
        public static int x = 5;
        public static int y = 5;

        public static int tempX = 5;
        public static int tempY = 5;


        public static void Update()
        {
            tempX = x;
            tempY = y;

            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);

            if (keyInfo.KeyChar == 's' || keyInfo.Key == ConsoleKey.DownArrow)
                y++;

            if (keyInfo.KeyChar == 'w' || keyInfo.Key == ConsoleKey.UpArrow)
                y--;

            if (keyInfo.KeyChar == 'a' || keyInfo.Key == ConsoleKey.LeftArrow)
                x--;

            if (keyInfo.KeyChar == 'd' || keyInfo.Key == ConsoleKey.RightArrow)
                x++;

            //Range Check Collision
            if (y < 0 || y == Map.map.GetLength(1) || x < 0 || x == Map.map.GetLength(0))
            {
                x = tempX;
                y = tempY;
            }

            //Collision Check with map object
            if (Map.map[x, y] == '█')
            {
                x = tempX;
                y = tempY;
            }
        }



        public static void Draw()
        {
            Console.SetCursorPosition(tempX + Program.offsetX, tempY+ Program.offsetY);
            Console.Write(Map.map[x, y]);
            Console.SetCursorPosition(x + Program.offsetX, y + Program.offsetY);
            Console.Write("A");
        }


    }
}
