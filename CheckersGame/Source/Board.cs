using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Source
{
    public class Board
    {
        public const int Size = 8;
        private Piece[,] squares = new Piece[Size, Size];

        public Piece GetPiece(int x, int y)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "Index was outside the bounds of the array.");
            }
            return squares[x, y];
        }

        public void SetPiece(int x, int y, Piece piece)
        {
            if (x < 0 || x >= Size || y < 0 || y >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "Index was outside the bounds of the array.");
            }
            squares[x, y] = piece;
        }

        public void Initialize()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = y % 2 == 0 ? 1 : 0; x < Size; x += 2)
                {
                    squares[x, y] = new Piece(PieceType.Man, PieceColor.White);
                }
            }

            for (int y = Size - 1; y >= Size - 3; y--)
            {
                for (int x = y % 2 == 0 ? 1 : 0; x < Size; x += 2)
                {
                    squares[x, y] = new Piece(PieceType.Man, PieceColor.Black);
                }
            }
        }
    }
}
