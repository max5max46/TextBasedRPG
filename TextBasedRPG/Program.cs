using System;
using System.IO;

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
        public static Map map = new Map();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //string[] convertTo2DArray = File.ReadAllText("map.txt").Split('\n');
            //char[,] map = new char[convertTo2DArray[1].Length, convertTo2DArray.Length];

            //for (int i = 0; i < convertTo2DArray.Length; i++)
            //{
            //    for (int j = 0; j < convertTo2DArray[i].Length; j++)
            //    {
            //        map[j, i] = (convertTo2DArray[i][j]);
            //    }
            //}

            //Drawing Map
            //for (int i = 0; i < map.GetLength(0); i++)
            //{
            //    for (int j = 0; j < map.GetLength(1); j++)
            //    {
            //        Console.SetCursorPosition(i, j);
            //        Console.Write(map[i, j]);
            //    }
            //}

            //Console.ReadKey(true);

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
