public class Solution
{
    public string SmallestPalindrome(string s)
    {
        int[] freq = new int[26];

        foreach (char c in s)
        {
            freq[c - 'a']++;
        }

        StringBuilder left = new StringBuilder();
        char middle = '\0';

        for (int i = 0; i < 26; i++)
        {
            left.Append(new string((char)('a' + i), freq[i] / 2));

            if ((freq[i] & 1) == 1)
            {
                middle = (char)('a' + i);
            }
        }

        char[] right = left.ToString().ToCharArray();
        Array.Reverse(right);


        if (middle == '\0')
        {
            return left.ToString() + new string(right);
        }

        return left.ToString() + middle + new string(right);
    }
}
