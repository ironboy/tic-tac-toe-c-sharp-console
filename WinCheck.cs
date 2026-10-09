using System.ComponentModel.Design;

static class WinCheck
{
    public static int[][][] WinCombos { get; } =
    {
        // Note:
        // In Tic Tac Toe there only
        // 8 combinations of slots you win the game with
        // So easy to hard code
        // In Connect 4 there are 69 combinations of slots
        // maybe better to create using a nested loop
        // over rows and cols + adding 3 extra in different
        // directions from the current col and row
        // and adding to list of combos in the loop

        // horizontal
        [[0,0],[0,1],[0,2]],
        [[1,0],[1,1],[1,2]],
        [[2,0],[2,1],[2,2]],
        // vertical
        [[0,0],[1,0],[2,0]],
        [[0,1],[1,1],[2,1]],
        [[0,2],[1,2],[2,2]],
        // diagonal
        [[0,0],[1,1],[2,2]],
        [[0,2],[1,1],[2,0]]
    };

    public static bool CheckIsWin(Board board, char markerColor)
    {
        // loop through all 8 win combos
        foreach (int[][] combo in WinCombos)
        {
            // loop through the positions in one combo
            bool won = true;
            foreach (int[] position in combo)
            {
                int row = position[0];
                int col = position[1];
                won = won && board.Matrix[row][col] == markerColor;
                if (!won) { break; }
            }
            // if a combo is won the game is won so no further
            // checking necessary
            if (won) { return true; }
        }
        // no combo is a win (all in marker color)
        // so return false
        return false;
    }

    public static bool IsTie(Board board)
    {
        // check if the board is full
        bool isFull = true;
        foreach (char[] row in board.Matrix)
        {
            foreach (char cell in row)
            {
                isFull = isFull && cell != ' ';
            }
        }
        // it's a tie if the board is full an noone has won
        return isFull && !CheckIsWin(board, 'X') && !CheckIsWin(board, 'O');
    }

}