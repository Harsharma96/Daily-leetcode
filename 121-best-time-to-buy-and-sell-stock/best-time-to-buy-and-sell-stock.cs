public class Solution {
    public int MaxProfit(int[] prices) {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices) {
          
            minPrice = Math.Min(minPrice, price);

            int profit = price - minPrice;

            maxProfit = Math.Max(maxProfit, profit);
        }

        return maxProfit;
    }
}