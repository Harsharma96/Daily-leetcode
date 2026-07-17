
public class Solution
{
    public int[] GcdValues(int[] nums, long[] queries)
    {
        int max = 0;
        foreach (int x in nums)
            if (x > max) max = x;

        int[] freq = new int[max + 1];
        foreach (int x in nums)
            freq[x]++;

        long[] cnt = new long[max + 1];

        for (int i = 1; i <= max; i++)
        {
            long total = 0;
            for (int j = i; j <= max; j += i)
                total += freq[j];

            cnt[i] = total * (total - 1) / 2;
        }

        for (int i = max; i >= 1; i--)
        {
            for (int j = i * 2; j <= max; j += i)
                cnt[i] -= cnt[j];
        }

        long[] prefix = new long[max + 1];
        for (int i = 1; i <= max; i++)
            prefix[i] = prefix[i - 1] + cnt[i];

        int[] ans = new int[queries.Length];

        for (int k = 0; k < queries.Length; k++)
        {
            long target = queries[k] + 1;

            int left = 1, right = max;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (prefix[mid] >= target)
                    right = mid;
                else
                    left = mid + 1;
            }

            ans[k] = left;
        }

        return ans;
    }
}