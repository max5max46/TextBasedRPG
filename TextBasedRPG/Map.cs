using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextBasedRPG
{

    internal class Map
    {
        Random RNG = new Random();
        public char[,] map;

        public Map(char[,] loadedMap)
        {
            map = loadedMap;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    char changeTile = map[i ,j];

                    switch (changeTile)
                    {
                        case 'X':
                            changeTile = '█';
                            break;

                        default:
                            changeTile = ' ';
                            break;
                    }

                    map[i, j] = changeTile;
                }
            }
        }

        public void Draw()
        {
            bool loop;


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

        public char CheckPosition(int x, int y)
        {
            return map[x, y];
        }



    }
}
