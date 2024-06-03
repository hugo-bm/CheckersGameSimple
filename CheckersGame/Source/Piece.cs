using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Source
{
    public enum PieceType
    {
        Man,
        King
    }

    public enum PieceColor
    {
        White,
        Black
    }

    public class Piece
    {
        public PieceType Type { get; set; }
        public PieceColor Color { get; set; }

        public Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }
    }
}
