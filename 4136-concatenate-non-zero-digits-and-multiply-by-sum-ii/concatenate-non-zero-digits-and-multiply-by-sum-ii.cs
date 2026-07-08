public class Solution
{
    const long MOD = 1000000007;

    public int[] SumAndMultiply(string s, int[][] queries)
    {
        int n = s.Length;

        long[] sumPrefix = new long[n + 1];     
        int[] countPrefix = new int[n + 1];     
        long[] valPrefix = new long[n + 1];     
        long[] pow10 = new long[n + 1];

        pow10[0] = 1;

        for (int i = 0; i < n; i++)
        {
            int digit = s[i] - '0';

            sumPrefix[i + 1] = sumPrefix[i] + digit;
            countPrefix[i + 1] = countPrefix[i];
            valPrefix[i + 1] = valPrefix[i];

            if (digit != 0)
            {
                countPrefix[i + 1]++;
                valPrefix[i + 1] = (valPrefix[i] * 10 + digit) % MOD;
            }

            pow10[i + 1] = (pow10[i] * 10) % MOD;
        }

        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            int l = queries[i][0];
            int r = queries[i][1];

            long sum = sumPrefix[r + 1] - sumPrefix[l];

            int leftCount = countPrefix[l];
            int rightCount = countPrefix[r + 1];
            int len = rightCount - leftCount;

            long x = (valPrefix[r + 1] - (valPrefix[l] * pow10[len]) % MOD + MOD) % MOD;

            ans[i] = (int)((x * sum) % MOD);
        }

        return ans;
    }
}