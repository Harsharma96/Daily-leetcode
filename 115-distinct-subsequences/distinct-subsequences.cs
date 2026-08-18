public class Solution {
    public int NumDistinct(string s, string t) {
        int n = s.Length;
        int m = t.Length;

        long[] dp = new long[m + 1];
        dp[0] = 1; 

        for (int i = 1; i <= n; i++) {
            for (int j = m; j >= 1; j--) {
                if (s[i - 1] == t[j - 1]) {
                    dp[j] += dp[j - 1];
                }
            }
        }

        return (int)dp[m];
    }
}