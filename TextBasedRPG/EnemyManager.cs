using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TextBasedRPG
{
    internal class EnemyManager
    {
        int[,] enemyCords;
        Enemy[] chaserEnemys;
        EnemyRunner[] runnerEnemys;
        EnemyBouncer[] bouncerEnemys;

        public EnemyManager(char[,] loadedMap) 
        {
            int totalEnemys = 0;
            int chaserEnemyCount = 0;
            int runnerEnemyCount = 0;
            int bouncerEnemyCount = 0;

            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    if (loadedMap[i, j] == 'E')
                    {
                        enemyCount++;
                    }

                    if (loadedMap[i, j] == 'R')
                        runnerEnemyCount++;

                    if (loadedMap[i, j] == 'B')
                        bouncerEnemyCount++;
                }
            }

            chaserEnemys = new Enemy[chaserEnemyCount];
            runnerEnemys = new EnemyRunner[runnerEnemyCount];
            bouncerEnemys = new EnemyBouncer[bouncerEnemyCount];
            enemyCords = new int[chaserEnemyCount + runnerEnemyCount + bouncerEnemyCount, 2];
            chaserEnemyCount = 0;
            runnerEnemyCount = 0;
            bouncerEnemyCount = 0;

            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    totalEnemys = chaserEnemyCount + runnerEnemyCount + bouncerEnemyCount;

                    if (loadedMap[i, j] == 'E')
                    {
                        enemyCords[totalEnemys, 0] = i;
                        enemyCords[totalEnemys, 1] = j;
                        chaserEnemys[chaserEnemyCount] = new Enemy(enemyCords, totalEnemys);
                        chaserEnemyCount++;
                    }

                    if (loadedMap[i, j] == 'R')
                    {
                        enemyCords[totalEnemys, 0] = i;
                        enemyCords[totalEnemys, 1] = j;
                        runnerEnemys[runnerEnemyCount] = new EnemyRunner(enemyCords, totalEnemys);
                        runnerEnemyCount++;
                    }

                    if (loadedMap[i, j] == 'B')
                    {
                        enemyCords[totalEnemys, 0] = i;
                        enemyCords[totalEnemys, 1] = j;
                        bouncerEnemys[bouncerEnemyCount] = new EnemyBouncer(enemyCords, totalEnemys);
                        bouncerEnemyCount++;
                    }

                }
            }
        }


        public void Update()
        {
            for (int i = 0; i < chaserEnemys.Length; i++)
                chaserEnemys[i].Update(enemyCords);

            for (int i = 0; i < runnerEnemys.Length; i++)
                runnerEnemys[i].Update(enemyCords);

            for (int i = 0; i < bouncerEnemys.Length; i++)
                bouncerEnemys[i].Update(enemyCords);
        }

        public void Draw()
        {
            for (int i = 0; i < chaserEnemys.Length; i++)
                chaserEnemys[i].Draw();

            for (int i = 0; i < runnerEnemys.Length; i++)
                runnerEnemys[i].Draw();

            for (int i = 0; i < bouncerEnemys.Length; i++)
                bouncerEnemys[i].Draw();
        }

        public bool playerCollide(int playerX, int playerY, int damage = 0)
        {
            int index;

            for (int i = 0; i < enemyCords.GetLength(0); i++)
            {
                if (playerX == enemyCords[i, 0] && playerY == enemyCords[i, 1])
                {
                    index = i;
                    EnemyTakesDamage();
                    return true;
                }
            }
            return false;

            void EnemyTakesDamage()
            {
                
                for (int i = 0; i < chaserEnemys.Length; i++)
                    if (chaserEnemys[i].x == enemyCords[index, 0] || chaserEnemys[i].y == enemyCords[index, 1])
                    {
                        chaserEnemys[i].health -= damage;
                        if (chaserEnemys[i].health < 1)
                        {
                            enemyCords[index, 0] = 0;
                            enemyCords[index, 1] = 0;
                            Console.SetCursorPosition(chaserEnemys[i].x + Program.offsetX, chaserEnemys[i].y + Program.offsetY);
                            Console.Write(" ");
                        }
                    }

                for (int i = 0; i < runnerEnemys.Length; i++)
                    if (runnerEnemys[i].x == enemyCords[index, 0] || runnerEnemys[i].y == enemyCords[index, 1])
                    {
                        runnerEnemys[i].health -= damage;
                        if (runnerEnemys[i].health < 1)
                        {
                            enemyCords[index, 0] = 0;
                            enemyCords[index, 1] = 0;
                            Console.SetCursorPosition(runnerEnemys[i].x + Program.offsetX, runnerEnemys[i].y + Program.offsetY);
                            Console.Write(" ");
                        }
                    }

                for (int i = 0; i < bouncerEnemys.Length; i++)
                    if (bouncerEnemys[i].x == enemyCords[index, 0] || bouncerEnemys[i].y == enemyCords[index, 1])
                    {
                        bouncerEnemys[i].health -= damage;
                        if (bouncerEnemys[i].health < 1)
                        {
                            enemyCords[index, 0] = 0;
                            enemyCords[index, 1] = 0;
                            Console.SetCursorPosition(bouncerEnemys[i].x + Program.offsetX, bouncerEnemys[i].y + Program.offsetY);
                            Console.Write(" ");
                        }
                    }
            }
        }
    }
}
