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
            for (int j = 1; j*j <= n; j++) {
                var square = j*j;
                if (i - square >= 0) {
                    dp[i] = Math.Min(dp[i], dp[i - square] + 1);
                } else {
                    break;
                }
            }
        }

        return dp[n];
    }
}