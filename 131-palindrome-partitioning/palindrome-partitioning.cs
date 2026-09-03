public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        var result = new List<IList<string>>();
        var current = new List<string>();

        Backtrack(0);

        return result;

        void Backtrack(int start)
        {
            
            if (start == s.Length)
            {
                result.Add(new List<string>(current));
                return;
            }

          
            for (int end = start; end < s.Length; end++)
            {
                if (IsPalindrome(start, end))
                {
                    current.Add(s.Substring(start, end - start + 1));

                 
                    Backtrack(end + 1);

                    current.RemoveAt(current.Count - 1);
                }
            }
        }

        bool IsPalindrome(int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}