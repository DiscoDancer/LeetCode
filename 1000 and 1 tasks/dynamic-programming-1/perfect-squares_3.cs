public class Solution {
    public int NumSquares(int n) {
        // получить число из квадратов
        // результирующая таблица
        var dp = new int[n + 1];

        // всегда можно получить число из суммы единичек
        // еще квадраты сразу впишем
        for (int i = 1; i <= n; i++) {
            if (i*i <= n) {
                dp[i*i] = 1;
            }
            if (dp[i] == 0) {
                dp[i] = i;
            }
        }

        for (int i = 1; i <= n; i++) {
            var j = 1;
            var square = j*j;

            while (square <= n && square <= i) {
                dp[i] = Math.Min(dp[i], dp[i - square] + 1);
                j++;
                square = j*j;
            }
        }

        return dp[n];
    }
}