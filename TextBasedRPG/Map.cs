using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG
{

    internal class Map
    {
        Random RNG = new Random();
        public char[,] map;

        public Map(int width, int length)
        {
            map = new char[width, length];
        }

        public void Draw()
        {
            bool loop;

            //Creating map
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ' ';
                }
            }

            //Generate Random Walls
            for (int i = 0; i < RNG.Next((int)(map.GetLength(0) * map.GetLength(1)) / 20, (int)(map.GetLength(0) * map.GetLength(1)) / 10); i++)
            {
                loop = true;
                while (loop)
                {
                    int k = RNG.Next(0, map.GetLength(0));
                    int j = RNG.Next(0, map.GetLength(1));

                    if (map[k, j] == ' ' && Program.player.x != k && Program.player.y != j && Program.enemy.x != k && Program.enemy.y != j)
                    {
                        map[k, j] = '█';
                        loop = false;
                    }
                }
            }

            //Drawing Border
            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.SetCursorPosition(i + Program.offsetX, Program.offsetY - 1);
                Console.Write('─');
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.SetCursorPosition(i + Program.offsetX, map.GetLength(1) + Program.offsetY);
                Console.Write('─');
            }

            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.SetCursorPosition(Program.offsetX - 1, i + Program.offsetY);
                Console.Write('│');
            }

            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.SetCursorPosition(map.GetLength(0) + Program.offsetX, i + Program.offsetY);
                Console.Write('│');
            }

            Console.SetCursorPosition(Program.offsetX - 1, Program.offsetY - 1);
            Console.Write('┌');

            Console.SetCursorPosition(Program.offsetX + map.GetLength(0), Program.offsetY - 1);
            Console.Write('┐');

            Console.SetCursorPosition(Program.offsetX - 1, Program.offsetY + map.GetLength(1));
            Console.Write('└');

            Console.SetCursorPosition(Program.offsetX + map.GetLength(0), Program.offsetY + map.GetLength(1));
            Console.Write('┘');

            //Drawing Map
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i + Program.offsetX, j + Program.offsetY);
                    Console.Write(map[i, j]);
                }
            }
        }



    }
}
