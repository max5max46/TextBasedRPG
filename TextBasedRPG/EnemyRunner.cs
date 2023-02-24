using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class EnemyRunner : GameCharacter
    {
        public char sprite = 'R';
        public int cordIndex;

        public EnemyRunner(int[,] enemyCords, int index)
        {
            cordIndex = index;
            x = enemyCords[index, 0];
            y = enemyCords[index, 1];
            tempX = enemyCords[index, 0];
            tempY = enemyCords[index, 1];
            health = 2;
            hitEnemy = false;
        }

        public void Update(int[,] enemyCords)
        {
            //Check to see if enemy is died, if yes, don't update 
            if (health == 0)
                return;


            //AI

            //Move Towards player
            if ((Program.player.x + Program.player.y) - (x + y) < 7 && (Program.player.x + Program.player.y) - (x + y) > -7)
            {
                if (Math.Abs(Program.player.x - x) > Math.Abs(Program.player.y - y))
                {
                    if (Program.player.x > x)
                        x--;
                    else
                        x++;
                }
                else
                {
                    if (Program.player.y > y)
                        y--;
                    else
                        y++;
                }
            }
            else


            //Random movement
            {
                switch (GetRandomNumber(1, 4))
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(sprite);
            Console.ResetColor();
        }
    }
}
