using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class Enemy : GameCharacter
    {
        public char sprite = 'E';

        public Enemy()
        {
            x = Program.player.x;
            y = Program.player.y;
            health = 3;
            hitEnemy = false;

            while (Program.player.x == x && Program.player.y == y)
            {
                x = RNG.Next(0, Program.mapX);
                y = RNG.Next(0, Program.mapY);
            }
        }

        public void Update()
        {
            //Check to see if enemy is died, if yes, don't update 
            if (health < 0)
                return;

            //Called by player upon the moment of death of a enemy
            if (health == 0)
            {
                sprite = ' ';
                Draw();
                health--;
            }


            tempX = x;
            tempY = y;

            if ((Program.player.x + Program.player.y) - (x + y) < 7 && (Program.player.x + Program.player.y) - (x + y) > -7)
            {
                if (Math.Abs(Program.player.x - x) > Math.Abs(Program.player.y - y))
                {
                    if (Program.player.x > x)
                        x++;
                    else
                        x--;
                }
                else
                {
                    if (Program.player.y > y)
                        y++;
                    else
                        y--;
                }
            }
            else
            {
                switch (RNG.Next(1,5))
                {
                    case 1:
                        x++;
                        break;
                    case 2:
                        x--;
                        break;
                    case 3:
                        y++;
                        break;
                    case 4:
                        y--;
                        break;
                }
            }


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

            if (Program.player.ComparePosition(x, y) && Program.player.TakeDamage() > 0)
            {
                x = tempX;
                y = tempY;
                hitEnemy = true;
                if (Program.player.TakeDamage(1) < 1)
                {
                    Program.gameLoop = false;
                }
            }
        }

        public void Draw()
        {
            //Check to see if enemy is died, if yes, don't draw 
            if (health < 0)
                return;

            

            if (hitEnemy == true)
            {
                Console.SetCursorPosition(Program.offsetX + 30, Program.offsetY + Program.map.map.GetLength(1) + 1);
                Console.Write("Enemy Hit Player");
                hitEnemy = false;
            }

            Console.SetCursorPosition(tempX + Program.offsetX, tempY + Program.offsetY);
            Console.Write(Program.map.map[tempX, tempY]);
            Console.SetCursorPosition(x + Program.offsetX, y + Program.offsetY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sprite);
            Console.ResetColor();
        }
    }
}
