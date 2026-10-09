static class StupidBot
{
    public static void MakeMove(Board board) // return 1-9
    {
        int move = 0;
        do
        {
            // set move to a random int between 1-9
            // 10 = upper boundary 
            // (always 1 more than largest possible number)
            move = Random.Shared.Next(1, 10);
        } while (!board.PlaceMarker(move));
    }
}