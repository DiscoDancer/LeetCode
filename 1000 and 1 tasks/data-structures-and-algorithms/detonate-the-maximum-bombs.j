import java.util.*;


class Solution {

    boolean isInside(double xc, double yc, double r,
                     double xp, double yp) {

        double dx = xp - xc;
        double dy = yp - yc;

        return dx*dx + dy*dy <= r*r;
    }


    public int maximumDetonation(int[][] bombs) {

        var max = 0;

        for (var i = 0; i < bombs.length; i++) {
            Queue<Integer> queue = new ArrayDeque<>();
            queue.add(i);
            var visited = new boolean[bombs.length];
            visited[i] = true;
            var score = 1;
            while (!queue.isEmpty()) {
                var cur = queue.poll();
                
                for (var j = 0; j < bombs.length; j++) {
                    if (i == j || visited[j]) {
                        continue;
                    }
                    if (isInside(bombs[cur][0], bombs[cur][1], bombs[cur][2],
                            bombs[j][0], bombs[j][1])) {
                        visited[j] = true;
                        score++;
                        queue.add(j);
                    }
                }
            }

            max = Math.max(max, score);
        }

        return max;
    }
}