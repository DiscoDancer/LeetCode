import java.util.*;

class Solution {


    public int maxEnvelopes(int[][] envelopes) {
        var n = envelopes.length;
        ArrayList<Integer>[] tableIBiggerThanThey = new ArrayList[n];
        var tableILessThanThey = new int[n];

        for (var i = 0; i < n; i++) {
            tableIBiggerThanThey[i] = new ArrayList<>();
        }

        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                if (i != j) {
                    if (envelopes[i][0] > envelopes[j][0] && envelopes[i][1] > envelopes[j][1]) {
                        tableIBiggerThanThey[i].add(j);
                    } else if (envelopes[i][0] < envelopes[j][0] && envelopes[i][1] < envelopes[j][1]) {
                        tableILessThanThey[i]++;
                    }
                }
            }
        }

        var dp = new int[n];

        var queue = new LinkedList<Integer>();

        for (var i = 0; i < n; i++) {
            dp[i] = 1;
            if (tableILessThanThey[i] == 0) {
                queue.add(i);
            }
        }

        var max = 1;

        while (!queue.isEmpty()) {
            var i = queue.poll();

            for (var j: tableIBiggerThanThey[i]) {
                tableILessThanThey[j]--;
                if (tableILessThanThey[j] == 0) {
                    queue.add(j);
                    dp[j] = Math.max(dp[j], dp[i] + 1);
                }
            }

            max = Math.max(max, dp[i]);
        }

        return max;
    }
}