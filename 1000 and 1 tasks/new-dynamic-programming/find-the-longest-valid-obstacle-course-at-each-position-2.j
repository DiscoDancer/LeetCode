import java.util.*;

// TL
// используется алгоритм отсюда https://leetcode.com/problems/longest-increasing-subsequence/description/?envType=study-plan-v2&envId=dynamic-programming

class Solution {

    // первый больше
    public int binarySearch(ArrayList<Integer> list, int x) {
        var l = 0;
        var r = list.size() - 1;

        while (l <= r) {
            var m = (r-l) / 2 + l;
            if (list.get(m) > x && (m == 0 || list.get(m-1) <= x)) {
                return m;
            }
            if (list.get(m) <= x) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return -1;
    }

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
                var j = binarySearch(minList, obstacles[i]);
                if (j != -1) {
                    minList.set(j, obstacles[i]);
                }
            }
        }

        return dp;
    }
}