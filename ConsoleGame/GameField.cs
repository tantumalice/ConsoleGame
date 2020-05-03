using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    static class GameField
    {
        public static Room[,] Field { get; private set; }

        private const int fieldSize = 10;

        static GameField()
        {
            Field = new Room[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; ++i)
            {
                for (int j = 0; j < fieldSize; ++j)
                {
                    Field[i, j] = new Room();
                }
            }
        }
    }
}
