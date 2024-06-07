public class Solution {
    public int MaxProfit(int[] prices) {
        // второй параметр показывает, если в наличии или нет
        var table = new int[prices.Length + 1, 2];

        // нету
        table[0, 0] = 0;
        // есть и чтобы появился надо купить
        table[0, 1] = -prices[0];
       
        for (int i = 1; i < prices.Length; i++) {
            // либо ничего не делаем, либо продаем что купили до этого
            // для того, чтобы продать, надо чтобы он был поэтому берем из table[i-1, 1]
            table[i, 0] = Math.Max(table[i-1, 1] + prices[i], table[i-1, 0]);
            // либо покупаем, либо ничего не делаем
            table[i, 1] = Math.Max(table[i-1, 0] - prices[i], table[i-1, 1]);
        }

        return Math.Max(table[prices.Length-1, 1], table[prices.Length-1, 0]);
    }
}