public class Solution {
    public int NumSquares(int n) {
        // получить число из квадратов
        // результирующая таблица
        var dp = new int[n + 1];

        var squaresList = new List<int>();

        // всегда можно получить число из суммы единичек
        // еще квадраты сразу впишем
        for (int i = 1; i <= n; i++) {
            if (i*i <= n) {
                squaresList.Add(i*i);
            }
            dp[i] = i;
        }

        foreach (var sq in squaresList) {
           if (sq <= n) {
               dp[sq] = 1;
           } 
           else {
               break;
           }
        }

        var squares = squaresList.ToArray();

        for (int i = 1; i <= n; i++) {
            foreach (var square in squares) {
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