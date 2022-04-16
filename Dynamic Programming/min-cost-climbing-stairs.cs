public class Solution {
    // шаг: идем с нуля и выбираем next или next-> next
    // думаем начать с 0 или с 1 (можно 2 варика посчитать)
    // условие остановки до
    // добавить 0 к массиву и ок, фейковый head (не работает)
    // Нужно просто заполнить табличку мб ?
    public int MinCostClimbingStairs(int[] cost) {
        var table = new int[cost.Length];
        table[0] = cost[0];
        table[1] = cost[1];
        // шаг 1, не важно начали с 1 или 0, потому что не умеем шагать на 2 шага назад
        for (int i = 2; i < cost.Length; i++) {
            table[i] = Math.Min(table[i - 1] + cost[i], table[i - 2] + cost[i]);
        }
        
        return Math.Min(table[table.Length - 1], table[table.Length - 2]);
    }    
}