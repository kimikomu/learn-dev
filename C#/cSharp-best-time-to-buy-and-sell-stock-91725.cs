// You are given an array prices where prices[i] is the price of a given stock on the ith day.
// You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
// Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

// Example 1:
// Input: prices = [7,1,5,3,6,4]
// Output: 5
// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

// Example 2:
// Input: prices = [7,6,4,3,1]
// Output: 0
// Explanation: In this case, no transactions are done and the max profit = 0.



// input: array of prices. each index represents a day and the num in each index represents the prica amount
// todo: find the maximum profit amount you can get from buying at the lowest point and selling at the highest
// output: the maximum profit, or 0 if no profit can be earned

public class Solution
{

    // USING POINTERS
    public int MaxProfit(int[] prices)
    {

        // we need at least 2 days to get a profit
        if (prices == null || prices.Length < 2) { return 0; }

        int maxProfit = 0;
        int buyDay = 0;     // first available buy day
        int sellDay = 1;    // first available sell day

        while (sellDay < prices.Length)
        {
            int buyPrice = prices[buyDay];
            int currentPrice = prices[sellDay];

            // if the price from yesterday is less than the price today...
            if (buyPrice < currentPrice)
            {
                // get the profit from when you bought and sold, if it's more than the maxProfit...
                int currentProfit = currentPrice - buyPrice;
                maxProfit = Math.Max(maxProfit, currentProfit);
            }
            else
            {
                // else move on
                buyDay = sellDay;
            }

            // try selling tomorrow
            sellDay++;
        }

        return maxProfit;
    }



    // WHOA
    public int MaxProfit(int[] prices) {

        int minPrice = int.MaxValue;
        int maxProfit = 0;
        
        foreach (int currentPrice in prices)
        {
            minPrice = Math.Min(currentPrice, minPrice);                // minimum price of stock is btw the current price or itself
            maxProfit = Math.Max(maxProfit, currentPrice - minPrice);   // max profit is btw the profit from the current price - min price, or itself
        }
        
        return maxProfit;
    }
}
