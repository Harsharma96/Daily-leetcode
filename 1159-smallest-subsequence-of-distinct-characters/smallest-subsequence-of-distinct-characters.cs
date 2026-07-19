public class Solution
{
    public string SmallestSubsequence(string s)
    {
        int[] lastIndex = new int[26];
  
        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i] - 'a'] = i;
        }

        Stack<char> stack = new Stack<char>();
        bool[] visited = new bool[26];

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (visited[c - 'a'])
                continue;

            while (stack.Count > 0 &&
                   stack.Peek() > c &&
                   lastIndex[stack.Peek() - 'a'] > i)
            {
                visited[stack.Pop() - 'a'] = false;
            }

            stack.Push(c);
            visited[c - 'a'] = true;
        }

        char[] result = stack.ToArray();
        Array.Reverse(result);

        return new string(result);
    }
}