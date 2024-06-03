using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Source
{
    public class GameCore
    {
        private Board board;
        private PieceColor currentPlayer;

        public GameCore()
        {
            board = new Board();
            board.Initialize();
            currentPlayer = PieceColor.White; // White starts the game
        }

        public bool MovePiece(Move move)
        {
            if (!IsValidPosition(move.FromX, move.FromY) || !IsValidPosition(move.ToX, move.ToY))
            {
                return false;
            }
            Piece piece = board.GetPiece(move.FromX, move.FromY);
            if (piece == null || piece.Color != currentPlayer)
            {
                return false;
            }

            int deltaX = move.ToX - move.FromX;
            int deltaY = move.ToY - move.FromY;

            // Verifica se o movimento é válido (movimento simples)
            if (Math.Abs(deltaX) == 1 && Math.Abs(deltaY) == 1)
            {
                return MakeSimpleMove(move, piece);
            }
            // Verifica se o movimento é uma captura
            else if (Math.Abs(deltaX) == 2 && Math.Abs(deltaY) == 2)
            {
                return MakeCaptureMove(move, piece);
            }

            return false;
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Board.Size && y >= 0 && y < Board.Size;
        }

        private bool MakeSimpleMove(Move move, Piece piece)
        {
            // Verifica se o destino está vazio
            if (board.GetPiece(move.ToX, move.ToY) == null)
            {
                board.SetPiece(move.ToX, move.ToY, piece);
                board.SetPiece(move.FromX, move.FromY, null);
                SwitchPlayer();
                return true;
            }

            return false;
        }

        private bool MakeCaptureMove(Move move, Piece piece)
        {
            int middleX = (move.FromX + move.ToX) / 2;
            int middleY = (move.FromY + move.ToY) / 2;

            Piece middlePiece = board.GetPiece(middleX, middleY);

            // Verifica se a peça do meio é do adversário
            if (middlePiece != null && middlePiece.Color != currentPlayer && board.GetPiece(move.ToX, move.ToY) == null)
            {
                board.SetPiece(move.ToX, move.ToY, piece);
                board.SetPiece(move.FromX, move.FromY, null);
                board.SetPiece(middleX, middleY, null);
                SwitchPlayer();
                return true;
            }

            return false;
        }

        private void SwitchPlayer()
        {
            currentPlayer = currentPlayer == PieceColor.White ? PieceColor.Black : PieceColor.White;
        }

        public Board GetBoard()
        {
            return board;
        }

        public PieceColor GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void DisplayBoard()
        {
            Board board = GetBoard();

            Console.WriteLine("  0 1 2 3 4 5 6 7"); // números de coordenadas X
            for (int y = 0; y < Board.Size; y++)
            {
                Console.Write(y + " "); // número de coordenada Y
                for (int x = 0; x < Board.Size; x++)
                {
                    Piece piece = board.GetPiece(x, y);
                    if (piece == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(piece.Color == PieceColor.White ? "W " : "B ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
