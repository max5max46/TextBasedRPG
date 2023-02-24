using System;
using System.IO;

namespace TextBasedRPG
{
    internal class Program
    {
        private static Random RNG = new Random();
        public static bool gameLoop = true;

        //Declaires where in the console you want everything to display can't be anything below 1x1
        public static int offsetX = 1;
        public static int offsetY = 1;

        //Declaires the size of map can be changed to anything above 1x1
        public static int mapX = 20;
        public static int mapY = 10;

        public static Player player;
        public static EnemyManager enemyManager;
        public static Map map;
        public static char[,] loadedMap;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[] convertTo2DArray = File.ReadAllText("map.txt").Split('\n');
            loadedMap = new char[convertTo2DArray[1].Length, convertTo2DArray.Length];

            for (int i = 0; i < convertTo2DArray.Length; i++)
            {
                for (int j = 0; j < convertTo2DArray[i].Length; j++)
                {
                    loadedMap[j,i] = convertTo2DArray[i][j];
                }
            }

            map = new Map(loadedMap);
            enemyManager = new EnemyManager(loadedMap);
            player = new Player(loadedMap);

            map.Draw();
            while (gameLoop)
            {
                Console.SetCursorPosition(offsetX, offsetY + map.map.GetLength(1) + 1);
                Console.Write("                                                    ");

                enemyManager.Draw();
                player.Draw();


                enemyManager.Update();
                player.Update();

            }
            Console.SetCursorPosition(offsetX, offsetY + map.map.GetLength(1) + 1);
            Console.Write("Game Over                                                  ");
            Console.ReadKey(true);
        }

        public static int GenerateRandomNumber(int min, int max) 
        {
            return RNG.Next(min, max + 1);
        }
        
    }
}
