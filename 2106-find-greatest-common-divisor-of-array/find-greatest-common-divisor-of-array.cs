public class Solution {
    public int FindGCD(int[] nums) {
         int min = nums[0], max = nums[0];
        foreach (int num in nums) {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        while (max % min != 0) {
            int temp = max % min;
            max = min;
            min = temp;
        }

        return min;
    }
}