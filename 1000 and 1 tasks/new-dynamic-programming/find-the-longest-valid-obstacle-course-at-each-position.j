import java.util.*;

class Solution {

    // TL


    public int[] longestObstacleCourseAtEachPosition(int[] obstacles) {

        var dp = new int[obstacles.length];
        for (var i = 0; i < obstacles.length; i++) {
            for (var j = 0; j < i; j++) {
                if (obstacles[j] <= obstacles[i]) {
                    dp[i] = Math.max(dp[i], dp[j] + 1);
                }
            }
        }

        for (var i = 0; i < dp.length; i++) {
            dp[i] += 1;
        }

        return dp;
    }
}