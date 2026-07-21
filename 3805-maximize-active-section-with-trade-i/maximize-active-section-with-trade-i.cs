public class Solution
{
    public int MaxActiveSectionsAfterTrade(string s)
    {
        int totalOnes = 0;
        foreach (char c in s)
        {
            if (c == '1')
                totalOnes++;
        }

        int prevZero = int.MinValue / 2;
        int maxGain = 0;

        int i = 0;
        while (i < s.Length)
        {
            int j = i;
            while (j < s.Length && s[j] == s[i])
                j++;

            int len = j - i;

            if (s[i] == '0')
            {
                maxGain = Math.Max(maxGain, prevZero + len);
                prevZero = len;
            }

            i = j;
        }

        return totalOnes + maxGain;
    }
}