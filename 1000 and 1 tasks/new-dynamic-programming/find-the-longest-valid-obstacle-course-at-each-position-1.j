import java.util.*;

// TL
// используется алгоритм отсюда https://leetcode.com/problems/longest-increasing-subsequence/description/?envType=study-plan-v2&envId=dynamic-programming

class Solution {
    public int[] longestObstacleCourseAtEachPosition(int[] obstacles) {
        var dp = new int[obstacles.length];

        var minList = new ArrayList<Integer>();
        for (var i = 0; i < obstacles.length; i++) {

            var diff = 0;
            for (var x: minList) {
                if (x > obstacles[i]) {
                    diff++;
                }
            }

            dp[i] = minList.size() + 1  - diff;

            if (i == 0 || obstacles[i] >= minList.get(minList.size() - 1)) {
                minList.add(obstacles[i]);
            }
            else {
                var j = minList.size() - 1;
                while (j >= 0) {
                    if (minList.get(j) > obstacles[i] && (j == 0 || minList.get(j - 1) <= obstacles[i])) {
                        minList.set(j, obstacles[i]);
                        break;
                    }
                    j--;
                }
            }
        }

        return dp;
    }
}