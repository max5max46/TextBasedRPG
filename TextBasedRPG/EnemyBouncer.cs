﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class EnemyBouncer : GameCharacter
    {
        public char sprite = 'B';
        public int cordIndex;

        public EnemyBouncer(int[,] enemyCords, int index)
        {
            cordIndex = index;
            x = enemyCords[index, 0];
            y = enemyCords[index, 1];
            tempX = enemyCords[index, 0];
            tempY = enemyCords[index, 1];
            health = 5;
            hitEnemy = false;
        }

        public void Update(int[,] enemyCords)
        {
            //Check to see if enemy is died, if yes, don't update 
            if (health == 0)
                return;


            //AI

            //Move Towards player
            if ((Program.player.x + Program.player.y) - (x + y) < 4 && (Program.player.x + Program.player.y) - (x + y) > -4)
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

            //Collision Check with map object
            if (Program.map.CheckPosition(x, y) == '█')
            {
                x = enemyCords[cordIndex, 0];
                y = enemyCords[cordIndex, 1];
            }

            //Collision Check for other enemys
            for (int i = 0; i < enemyCords.GetLength(0); i++)
            {
                if (enemyCords[i, 0] == x && enemyCords[i, 1] == y)
                {
                    x = enemyCords[cordIndex, 0];
                    y = enemyCords[cordIndex, 1];
                }
            }

            //Collision Check for Player
            if (Program.player.EnemyCollide(x, y, 1))
            {
                x = enemyCords[cordIndex, 0];
                y = enemyCords[cordIndex, 1];
            }

            tempX = enemyCords[cordIndex, 0];
            tempY = enemyCords[cordIndex, 1];


            enemyCords[cordIndex, 0] = x;
            enemyCords[cordIndex, 1] = y;
        }

        public void Draw()
        {
            //Check to see if enemy is died, if yes, don't draw 
            if (health == 0)
                return;


            Console.SetCursorPosition(tempX + Program.offsetX, tempY + Program.offsetY);
            Console.Write(Program.map.map[tempX, tempY]);
            Console.SetCursorPosition(x + Program.offsetX, y + Program.offsetY);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(sprite);
            Console.ResetColor();
        }
    }
}
