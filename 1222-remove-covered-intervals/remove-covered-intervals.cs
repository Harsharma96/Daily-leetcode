public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        
        Array.Sort(intervals, (a, b) => 
        {
            if (a[0] == b[0])
                return b[1].CompareTo(a[1]); 
            return a[0].CompareTo(b[0]);     
        });

        int count = 0;
        int maxEnd = 0;

        foreach (var interval in intervals)
        {
            int end = interval[1];

            if (end > maxEnd)
            {
                count++;
                maxEnd = end;
            }
        }

        return count;
    }
}