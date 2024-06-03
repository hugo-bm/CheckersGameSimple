using CheckersGame.Source;

class Program
{
    static void Main(string[] args)
    {
        GameCore game = new GameCore();
        while (true)
        {
            //Console.Clear();
           game.DisplayBoard();
            Console.WriteLine($"Current Player: {game.GetCurrentPlayer()}");

            Console.Write("Enter move (fromX fromY toX toY): ");
            string input = Console.ReadLine();
            string[] parts = input.Split();
            if (parts.Length != 4)
            {
                Console.WriteLine("Invalid input. Please enter move as 'fromX fromY toX toY'.");
                continue;
            }

            int fromX = int.Parse(parts[0]);
            int fromY = int.Parse(parts[1]);
            int toX = int.Parse(parts[2]);
            int toY = int.Parse(parts[3]);

            Move move = new Move(fromX, fromY, toX, toY);
            if (!game.MovePiece(move))
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }

    
    
}
