using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckersGame.Source;

namespace CheckersGame.Tests
{
    public class CheckersGameIntegrationTests
    {
        [Fact]
        public void TestInitializeBoard()
        {
            GameCore game = new GameCore();
            Board board = game.GetBoard();
            Piece piece = board.GetPiece(0, 1);
            Assert.NotNull(piece);
            Assert.Equal(PieceColor.White, piece.Color);
        }
    }
}
