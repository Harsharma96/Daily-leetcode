public class Solution
{
    public int MinimumPushes(string word)
    {
        int[] freq = new int[26];

        foreach (char c in word)
        {
            freq[c - 'a']++;
        }

        Array.Sort(freq);
        Array.Reverse(freq);

        int ans = 0;

        for (int i = 0; i < 26; i++)
        {
            if (freq[i] == 0) break;

            ans += freq[i] * (i / 8 + 1);
        }

        return ans;
    }
}