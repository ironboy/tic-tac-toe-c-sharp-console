class Game
{
    private Board _board;
    private string? _playerXName;
    private string? _playerOName;

    public Game()
    {
        _board = new Board();
        AskForNames();
        MainGameLoop();
    }

    private void AskForNames()
    {
        Console.WriteLine("Välkommen till TIC-TAC-TOE!");
        Console.Write("Spelare X:s namn: ");
        _playerXName = Console.ReadLine()!;
        Console.Write("Spelare O:s namn: ");
        _playerOName = Console.ReadLine()!;
    }

    private void MainGameLoop()
    {
        while (true) // break this outer loop when someone wins
        {
            while (true) // break this loop when someone makes a valid move
            {
                Console.Clear();
                _board.Render();
                Console.WriteLine();
                Console.WriteLine(
                    $"{(_board.CurrentMarker == 'X'
                     ? _playerXName : _playerOName)}:s ({_board.CurrentMarker}) tur:"
                );
                int move = 0;
                string moveAsString = Console.ReadLine()!;
                int.TryParse(moveAsString, out move);
                if (move != 0 && _board.PlaceMarker(move)) { break; }
            }
        }
    }

}