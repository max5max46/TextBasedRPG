using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Program
    {
        public static bool gameLoop = true;

        //Declaires where in the console you want everything to display can't be anything below 1x1
        public static int offsetX = 1;
        public static int offsetY = 1;
        
        //Declaires the size of map can be changed to anything above 1x1
        public static int mapX = 20;
        public static int mapY = 10;

        public static Player player = new Player();
        public static Enemy enemy = new Enemy();
        public static Map map = new Map(mapX, mapY);

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            map.Draw();
            while (gameLoop)
            {
                Console.SetCursorPosition(offsetX, offsetY + map.map.GetLength(1) + 1);
                Console.Write("                                                    ");

                enemy.Draw();
                player.Draw();
                enemy.Update();
                player.Update();

            }
            Console.SetCursorPosition(offsetX, offsetY + map.map.GetLength(1) + 1);
            Console.Write("Game Over                                                  ");
            Console.ReadKey(true);
        }
    }
}
