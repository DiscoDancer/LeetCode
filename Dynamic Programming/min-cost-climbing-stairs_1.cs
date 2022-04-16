public class Solution {
    // шаг: идем с нуля и выбираем next или next-> next
    // думаем начать с 0 или с 1 (можно 2 варика посчитать)
    // условие остановки до
    // добавить 0 к массиву и ок, фейковый head (не работает)
    // Нужно просто заполнить табличку мб ?
    public int MinCostClimbingStairs(int[] cost) {
        var a = cost[0];
        var b = cost[1];
        int c = int.MaxValue;
        
        for (int i = 2; i < cost.Length; i++) {
            c = Math.Min(a, b) + cost[i];
            int k = b;
            b = c;
            a = k;
        }
        
        return Math.Min(b, a);
    }    
}