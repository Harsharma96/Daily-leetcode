public class Solution
{
    public bool HasAllCodes(string s, int k)
    {
        if (k > s.Length) return false;

        int need = 1 << k;
        bool[] seen = new bool[need];
        int count = 0;
        int mask = need - 1;
        int hash = 0;

        for (int i = 0; i < s.Length; i++)
        {
            hash = ((hash << 1) & mask) | (s[i] - '0');

            if (i >= k - 1)
            {
                if (!seen[hash])
                {
                    seen[hash] = true;
                    count++;

                    if (count == need)
                        return true;
                }
            }
        }

        return false;
    }
}