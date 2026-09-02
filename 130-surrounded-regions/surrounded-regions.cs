public class Solution
{
    public void Solve(char[][] board)
    {
        if (board == null || board.Length == 0)
            return;

        int rows = board.Length;
        int cols = board[0].Length;

       
        for (int r = 0; r < rows; r++)
        {
            DFS(board, r, 0);
            DFS(board, r, cols - 1);
        }

        for (int c = 0; c < cols; c++)
        {
            DFS(board, 0, c);
            DFS(board, rows - 1, c);
        }

       
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == 'O')
                {
                    board[r][c] = 'X';
                }
                else if (board[r][c] == '#')
                {
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void DFS(char[][] board, int r, int c)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        if (r < 0 || r >= rows || c < 0 || c >= cols)
            return;

        if (board[r][c] != 'O')
            return;

        board[r][c] = '#';

        DFS(board, r + 1, c);
        DFS(board, r - 1, c);
        DFS(board, r, c + 1);
        DFS(board, r, c - 1);
    }
}