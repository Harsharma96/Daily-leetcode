public class Solution
{
    public string LargestNumber(int[] nums)
    {
        string[] arr = nums.Select(x => x.ToString()).ToArray();

        Array.Sort(arr, (a, b) =>
        {
            string ab = a + b;
            string ba = b + a;

            return string.Compare(ba, ab, StringComparison.Ordinal);
        });

        if (arr[0] == "0")
            return "0";

        return string.Concat(arr);
    }
}