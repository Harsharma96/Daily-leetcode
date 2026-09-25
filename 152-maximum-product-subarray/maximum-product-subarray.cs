public class Solution {
    public int MaxProduct(int[] nums) {
        int maxProduct = nums[0];
        int minProduct = nums[0];
        int result = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            int num = nums[i];

            if (num < 0) {
                int temp = maxProduct;
                maxProduct = minProduct;
                minProduct = temp;
            }

            maxProduct = Math.Max(num, maxProduct * num);
            minProduct = Math.Min(num, minProduct * num);

            result = Math.Max(result, maxProduct);
        }

        return result;
    }
}