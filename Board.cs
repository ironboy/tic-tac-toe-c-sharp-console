class Board
{


    // a "jagged" two-dimensional array in C#
    private char[][] _board =
    {
        [' ', ' ', ' '],
        [' ', 'X', ' '],
        [' ', ' ', 'O']
    };

    public void Render()
    {
        // loop through each row
        foreach (char[] row in _board)
        {
            // loop through each column
            foreach (char cell in row)
            {
                Console.Write(cell);
            }
            Console.WriteLine("");
        }
    }



}