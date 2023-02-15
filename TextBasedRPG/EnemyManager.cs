using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{
    internal class EnemyManager
    {
        int[,] enemyCords;
        Enemy[] enemys;

        public EnemyManager(char[,] loadedMap) 
        {
            int enemyCount = 0;
            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    if (loadedMap[i, j] == 'E')
                    {
                        enemyCount++;
                    }

                }
            }
            enemys = new Enemy[enemyCount];
            enemyCords = new int[enemyCount, 2];
            enemyCount = 0;
            for (int i = 0; i < loadedMap.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMap.GetLength(1); j++)
                {
                    if (loadedMap[i, j] == 'E')
                    {
                        enemyCords[enemyCount, 0] = i;
                        enemyCords[enemyCount, 1] = j;
                        enemys[enemyCount] = new Enemy(enemyCords, enemyCount);
                        enemyCount++;
                    }

                }
            }
        }


        public void Update()
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].Update(enemyCords, i);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].Draw();
            }
        }

        public bool playerCollide(int playerX, int playerY, int damage = 0)
        {
            int index;

            for (int i = 0; i < enemyCords.Length; i++)
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
                enemys[index].health -= damage;
                Console.SetCursorPosition(Program.offsetX, Program.offsetY + Program.map.map.GetLength(1) + 1);
                Console.Write("Player Hit the Enemy");
                if (enemys[index].health < 1)
                {

                }
            }
        }


        
    }
}
