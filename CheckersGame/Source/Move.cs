using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Source
{
    public class Move
    {
        public int FromX { get; }
        public int FromY { get; }
        public int ToX { get; }
        public int ToY { get; }

        public Move(int fromX, int fromY, int toX, int toY)
        {
            FromX = fromX;
            FromY = fromY;
            ToX = toX;
            ToY = toY;
        }
    }
}
