using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersGame.Source;
using Xunit;

namespace CheckersGame.Tests
{
    public class CheckersGameTests
    {
        [Fact]
        public void TestMovePiece_ValidSimpleMove()
        {
            GameCore game = new GameCore();
            Move move = new Move(1, 2, 2, 3); // Exemplo de movimento válido
            bool result = game.MovePiece(move);
            Assert.True(result);
        }

        [Fact]
        public void TestMovePiece_InvalidMove()
        {
            GameCore game = new GameCore();
            Move move = new Move(2, 5, 5, 6); // Exemplo de movimento inválido
            bool result = game.MovePiece(move);
            Assert.False(result);
        }

        [Fact]
        public void TestMovePiece_ValidCaptureMove()
        {
            GameCore game = new GameCore();
            Board board = game.GetBoard();
            board.SetPiece(2, 3, new Piece(PieceType.Man, PieceColor.Black)); // Adiciona peça preta para capturar

            Move move = new Move(1, 2, 3, 4); // Movimento de captura
            bool result = game.MovePiece(move);
            Assert.True(result);
            Assert.Null(board.GetPiece(2, 3)); // Peça capturada foi removida
            Assert.NotNull(board.GetPiece(3, 4)); // Peça movida para a nova posição
        }

        [Fact]
        public void TestMovePiece_InvalidCaptureMove_NoOpponentPiece()
        {
            GameCore game = new GameCore();
            Move move = new Move(2, 5, 4, 3); // Tentativa de captura sem peça adversária
            bool result = game.MovePiece(move);
            Assert.False(result);
        }

        [Fact]
        public void TestMovePiece_InvalidCaptureMove_OccupiedDestination()
        {
            GameCore game = new GameCore();
            Board board = game.GetBoard();
            board.SetPiece(3, 4, new Piece(PieceType.Man, PieceColor.Black)); // Adiciona peça preta para capturar
            board.SetPiece(4, 3, new Piece(PieceType.Man, PieceColor.White)); // Destino já ocupado

            Move move = new Move(2, 5, 4, 3); // Tentativa de captura com destino ocupado
            bool result = game.MovePiece(move);
            Assert.False(result);
        }

        [Fact]
        public void TestSwitchPlayer()
        {
            GameCore game = new GameCore();
            Assert.Equal(PieceColor.White, game.GetCurrentPlayer());

            Move move = new Move(1, 2, 2, 3); // Movimento válido para branco
            game.MovePiece(move);
            Assert.Equal(PieceColor.Black, game.GetCurrentPlayer());

            move = new Move(2, 5, 3, 4); // Movimento válido para preto
            game.MovePiece(move);
            Assert.Equal(PieceColor.White, game.GetCurrentPlayer());
        }

        [Fact]
        public void TestInitializeBoard()
        {
            GameCore game = new GameCore();
            Board board = game.GetBoard();

            // Verifica se as peças brancas estão na posição inicial correta
            for (int y = 0; y < 3; y++)
            {
                for (int x = (y % 2 == 0 ? 1 : 0); x < Board.Size; x += 2)
                {
                    Piece piece = board.GetPiece(x, y);
                    Assert.NotNull(piece);
                    Assert.Equal(PieceColor.White, piece.Color);
                }
            }

            // Verifica se as peças pretas estão na posição inicial correta
            for (int y = Board.Size - 1; y >= Board.Size - 3; y--)
            {
                for (int x = (y % 2 == 0 ? 1 : 0); x < Board.Size; x += 2)
                {
                    Piece piece = board.GetPiece(x, y);
                    Assert.NotNull(piece);
                    Assert.Equal(PieceColor.Black, piece.Color);
                }
            }
        }

    }
}
