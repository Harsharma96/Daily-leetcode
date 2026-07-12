public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int[] sorted = arr
            .Distinct()
            .OrderBy(x => x)
            .ToArray();

        Dictionary<int, int> rankMap = new Dictionary<int, int>();

        for (int i = 0; i < sorted.Length; i++)
        {
            rankMap[sorted[i]] = i + 1;
        }

        int[] result = new int[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            result[i] = rankMap[arr[i]];
        }

        return result;
    }
}