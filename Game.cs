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
        Console.WriteLine("För att skapa en dum datorspelare lägg till * någonstans i spelarens namn\n");
        Console.Write("Spelare X:s namn: ");
        _playerXName = Console.ReadLine()!;
        Console.Write("Spelare O:s namn: ");
        _playerOName = Console.ReadLine()!;
    }

    private void MainGameLoop()
    {
        while (true) // break this outer loop when someone wins
        {
            string? currentPlayer =
             _board.CurrentMarker == 'X' ?
                _playerXName : _playerOName;
            // Check if the player is a stupid bot
            if (currentPlayer!.Contains('*'))
            {
                StupidBot.MakeMove(_board);
            }
            else
            {
                // Human
                while (true) // break this loop when someone makes a valid move
                {
                    Console.Clear();
                    _board.Render();
                    Console.WriteLine();
                    Console.WriteLine(
                        $"{currentPlayer}:s ({_board.CurrentMarker}) tur:"
                    );
                    int move = 0;
                    string moveAsString = Console.ReadLine()!;
                    int.TryParse(moveAsString, out move);
                    if (move != 0 && _board.PlaceMarker(move)) { break; }
                }
            }
            // Render after move
            Console.Clear();
            _board.Render();

            // Check for win or tie
            if (WinCheck.CheckIsWin(_board, 'X'))
            {
                Console.WriteLine($"{_playerXName} vann!");
                break;
            }
            else if (WinCheck.CheckIsWin(_board, 'O'))
            {
                Console.WriteLine($"{_playerOName} vann!");
                break;
            }
            else if (WinCheck.IsTie(_board))
            {
                Console.WriteLine("Det blev oavgjort!");
                break;
            }
        }
    }

}