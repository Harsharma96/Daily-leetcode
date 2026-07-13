public class Solution
{
    public IList<int> SequentialDigits(int low, int high)
    {
        List<int> result = new List<int>();

        string digits = "123456789";

        int lowLength = low.ToString().Length;
        int highLength = high.ToString().Length;

        for (int len = lowLength; len <= highLength; len++)
        {
            for (int i = 0; i + len <= digits.Length; i++)
            {
                int num = int.Parse(digits.Substring(i, len));

                if (num >= low && num <= high)
                {
                    result.Add(num);
                }
            }
        }

        return result;
    }
}