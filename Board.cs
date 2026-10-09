using System.Diagnostics.Metrics;

class Board
{


    // a "jagged" two-dimensional array in C#
    private char[][] _board =
    {
        [' ', ' ', ' '],
        [' ', ' ', ' '],
        [' ', ' ', ' ']
    };

    // current player/marker
    private char _currentMarker = 'X';

    public void Render()
    {
        Console.WriteLine("-------------");
        // loop through each row
        int counter = 1;
        foreach (char[] row in _board)
        {
            // loop through each column
            foreach (char cell in row)
            {
                Console.Write($"| {(cell == ' ' ? counter++ : cell.ToString())} ");
            }
            Console.WriteLine("|");
            Console.WriteLine("-------------");
        }
    }

    public bool placeMarker(int row, int col)
    {
        // if the board position isn't empty
        if (_board[row][col] != ' ')
        {
            return false;
        }
        // the move is ok - update the board
        _board[row][col] = _currentMarker;
        // toggle marker color
        _currentMarker = _currentMarker == 'X' ? 'O' : 'X';
        return true;
    }



}