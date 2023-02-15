using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player : GameCharacter
    {
        public Player(char[,] loadedMap)
        {
            health = 5;
            hitEnemy = false;

            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    if (loadedMap[i, j] == 'P')
                    {
                        x = i;
                        y = j;
                    }

                }
            }
            tempX = x;
            tempY = y;

        }

        public void Update()
        {
            if (health < 1)
            {
                x = Program.map.map.GetLength(0) + 2;
                y = Program.map.map.GetLength(1) + 2;
                return;
            }


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
            if (y < 0 || y == Program.map.map.GetLength(1) || x < 0 || x == Program.map.map.GetLength(0))
            {
                x = tempX;
                y = tempY;
            }

            //Collision Check with map object
            if (Program.map.map[x, y] == '█')
            {
                x = tempX;
                y = tempY;
            }

            if (Program.enemyManager.playerCollide(x, y, 1))
            {
                x = tempX;
                y = tempY;
            }
        }



        public void Draw()
        {
            Console.SetCursorPosition(tempX + Program.offsetX, tempY+ Program.offsetY);
            Console.Write(Program.map.map[tempX, tempY]);
            Console.SetCursorPosition(x + Program.offsetX, y + Program.offsetY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }

        public bool EnemyCollide(int enemyX, int enemyY, int damage = 0)
        {
            if (enemyX == x && enemyY == y)
            {
                PlayerTakesDamage();
                return true;
            }
            return false;

            void PlayerTakesDamage()
            {
                health -= damage;
                Console.SetCursorPosition(Program.offsetX + 30, Program.offsetY + Program.map.map.GetLength(1) + 1);
                Console.Write("Enemy Hit the Player");
                if (health < 1)
                {

                }
            }
        }
    }
}
