public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        int total = m * n;

        k %= total;

        int[][] result = new int[m][];
        for (int i = 0; i < m; i++)
            result[i] = new int[n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int index = i * n + j;
                int newIndex = (index + k) % total;

                result[newIndex / n][newIndex % n] = grid[i][j];
            }
        }

        IList<IList<int>> ans = new List<IList<int>>();
        foreach (var row in result) {
            ans.Add(row.ToList());
        }

        return ans;
    }
}