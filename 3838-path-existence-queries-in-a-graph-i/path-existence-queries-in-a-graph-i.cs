public class Solution {
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int[] group = new int[n];
        int g = 0;

        group[0] = 0;

        for (int i = 1; i < n; i++) {
            if (nums[i] - nums[i - 1] > maxDiff) {
                g++;
            }
            group[i] = g;
        }

        bool[] ans = new bool[queries.Length];

        for (int i = 0; i < queries.Length; i++) {
            int u = queries[i][0];
            int v = queries[i][1];

            ans[i] = group[u] == group[v];
        }

        return ans;
    }
}