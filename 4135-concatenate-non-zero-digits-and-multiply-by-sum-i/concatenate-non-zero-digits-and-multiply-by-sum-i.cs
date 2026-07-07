public class Solution 
{
    public long SumAndMultiply(int n) 
    {
        long x = 0;
        long sum = 0;

        string s = n.ToString();

        foreach(char ch in s)
        {
            if(ch != '0')
            {
                int digit = ch - '0';

                x = x * 10 + digit;
                sum += digit;       
            }
        }

        return x * sum;
    }
}