public class Solution
{
    private const long LIMIT = 1000001;

    private long CombCap(int n, int r)
    {
        if (r < 0 || r > n) return 0;

        r = Math.Min(r, n - r);
        long ans = 1;

        for (int i = 1; i <= r; i++)
        {
            ans = ans * (n - r + i) / i;
            if (ans >= LIMIT) return LIMIT;
        }

        return Math.Min(ans, LIMIT);
    }

    private long CountWays(int[] cnt)
    {
        int total = 0;
        foreach (int x in cnt)
            total += x;

        long ans = 1;
        int rem = total;

        foreach (int x in cnt)
        {
            if (x == 0) continue;

            ans *= CombCap(rem, x);
            if (ans >= LIMIT) return LIMIT;

            rem -= x;
        }

        return Math.Min(ans, LIMIT);
    }

    public string SmallestPalindrome(string s, int k)
    {
        int[] freq = new int[26];

        foreach (char c in s)
            freq[c - 'a']++;

        int[] half = new int[26];
        string mid = "";

        for (int i = 0; i < 26; i++)
        {
            half[i] = freq[i] / 2;

            if ((freq[i] & 1) == 1)
                mid += (char)('a' + i);
        }

        if (CountWays(half) < k)
            return "";

        int halfLen = s.Length / 2;
        StringBuilder left = new StringBuilder();

        for (int pos = 0; pos < halfLen; pos++)
        {
            for (int c = 0; c < 26; c++)
            {
                if (half[c] == 0)
                    continue;

                half[c]--;

                long ways = CountWays(half);

                if (ways >= k)
                {
                    left.Append((char)('a' + c));
                    break;
                }

                k -= (int)ways;
                half[c]++;
            }
        }

        char[] right = left.ToString().ToCharArray();
        Array.Reverse(right);

        return left.ToString() + mid + new string(right);
    }
}