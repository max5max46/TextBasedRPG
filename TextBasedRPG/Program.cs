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
                DrawHUD();


                enemyManager.Update();
                player.Update();

            }
            Console.SetCursorPosition(offsetX + 1, offsetY + map.map.GetLength(1) + 1);
            Console.Write("Game Over");
            Console.ReadKey(true);
        }

        static void DrawHUD()
        {
            Console.SetCursorPosition(offsetX - 1, offsetY + map.map.GetLength(1) + 0); Console.Write("├─────────────────────────────────────────────────");
            Console.SetCursorPosition(offsetX - 1, offsetY + map.map.GetLength(1) + 1); Console.Write("│                                                │");
            Console.SetCursorPosition(offsetX - 1, offsetY + map.map.GetLength(1) + 2); Console.Write("├────────────────────────────────────────────────┤");
            Console.SetCursorPosition(offsetX - 1, offsetY + map.map.GetLength(1) + 3); Console.Write("│ Player health:                                 │");
            Console.SetCursorPosition(offsetX - 1, offsetY + map.map.GetLength(1) + 4); Console.Write("│ Enemy health:                                  │");
            Console.SetCursorPosition(offsetX - 1, offsetY + map.map.GetLength(1) + 5); Console.Write("└────────────────────────────────────────────────┘");

            Console.SetCursorPosition(offsetX + 17, offsetY + map.map.GetLength(1) + 3); Console.Write(player.health);
        }


        public static int GenerateRandomNumber(int min, int max) 
        {
            return RNG.Next(min, max + 1);
        }
        
    }
}
