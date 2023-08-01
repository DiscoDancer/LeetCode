public class Solution {
    // см мои страдания с iii и ii
    public int MaxProfit(int k, int[] prices) {
        var table = new int[prices.Length + 1, 2, k*2+1];
        // base кейсы уже прописаны (тк везде 0)
        // если ли разница куда поставить loop tr ? попал с первого раза
        for (var dayIndex = prices.Length-1; dayIndex >= 0; dayIndex--) {
            for (var hold = 0; hold < 2; hold++) {
                for (var tr = 0; tr < k*2; tr++) {
                    var doNothing = table[dayIndex+1, hold, tr];
                    if (hold == 0) {
                        var buy = table[dayIndex+1, 1, tr+1] - prices[dayIndex];
                        table[dayIndex, hold, tr] = Math.Max(doNothing, buy);
                    }
                    else if (hold == 1) {
                        var sell = table[dayIndex+1, 0, tr +1] + prices[dayIndex];
                        table[dayIndex, hold, tr] = Math.Max(doNothing, sell);
                    }
                }
            }
        }

        var max = 0;
        for (int tr = 0; tr <= k*2; tr++) {
            max = Math.Max(max, table[0,0,tr]);
        }

        return max;
    }
}