import java.util.*;

// TL

class Solution {


    public int maxEnvelopes(int[][] envelopes) {
        var n = envelopes.length;
        ArrayList<Integer>[] tableIBiggerThanThey = new ArrayList[n];
        ArrayList<Integer>[] tableILessThanThey = new ArrayList[n];

        for (var i = 0; i < n; i++) {
            tableIBiggerThanThey[i] = new ArrayList<>();
            tableILessThanThey[i] = new ArrayList<>();
        }

        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                if (i != j) {
                    if (envelopes[i][0] > envelopes[j][0] && envelopes[i][1] > envelopes[j][1]) {
                        tableIBiggerThanThey[i].add(j);
                    } else if (envelopes[i][0] < envelopes[j][0] && envelopes[i][1] < envelopes[j][1]) {
                        tableILessThanThey[i].add(j);
                    }
                }
            }
        }

        var dp = new int[n];

        var queue = new LinkedList<Integer>();

        for (var i = 0; i < n; i++) {
            dp[i] = 1;
            if (tableILessThanThey[i].isEmpty()) {
                queue.add(i);
            }
        }

        while (!queue.isEmpty()) {
            var i = queue.poll();

            for (var j: tableIBiggerThanThey[i]) {
                if (tableILessThanThey[j].remove((Integer) i)) {
                    if (tableILessThanThey[j].isEmpty()) {
                        queue.add(j);
                        dp[j] = Math.max(dp[j], dp[i] + 1);
                    }
                }
            }
        }
        
        return Arrays.stream(dp).max().getAsInt();
    }
}