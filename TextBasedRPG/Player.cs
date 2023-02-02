using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Player : GameCharacter
    {
        public Player()
        {
            health = 5;
            hitEnemy = false;

            x = RNG.Next(0, Program.mapX);
            y = RNG.Next(0, Program.mapY);
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

            if (Program.enemy.x == x && Program.enemy.y == y && Program.enemy.health > 0)
            {
                Program.enemy.health--;
                hitEnemy = true;
                x = tempX;
                y = tempY;
                if (Program.enemy.health == 0)
                {
                    Program.enemy.Update();
                }
            }
        }



        public void Draw()
        {
            

            if (hitEnemy == true)
            {
                Console.SetCursorPosition(Program.offsetX, Program.offsetY + Program.map.map.GetLength(1) + 1);
                Console.Write("Player Hit the Enemy");
                hitEnemy = false;
            }


            Console.SetCursorPosition(tempX + Program.offsetX, tempY+ Program.offsetY);
            Console.Write(Program.map.map[x, y]);
            Console.SetCursorPosition(x + Program.offsetX, y + Program.offsetY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }


    }
}
