public class Solution {
    // мы лочим следующий день продажей
    // нужно окинуть решение о продажи в каком-то из случаев
    // 1. если у след дня цена выше, чем у пред
    // 2 ? что-то с покупкой
    
    // backtracking
    // идти от конца
    // мб обсчитать весь массив
    public int MaxProfit(int[] prices) {
        if (prices.Length == 1) {
            return 0;
        }
        
        var reset = 0;
        var sold = int.MinValue;
        var held = int.MinValue;
        
        for (int i = 0; i < prices.Length; i++) {
            var presold = sold;
            
            sold = held + prices[i];
            held = Math.Max(held, reset - prices[i]);
            reset = Math.Max(reset, presold);
        }
        
        return Math.Max(sold, reset);
    }
}