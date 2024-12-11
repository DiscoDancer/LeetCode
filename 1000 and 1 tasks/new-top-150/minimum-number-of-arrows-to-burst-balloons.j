import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;

class Solution {

    public int findMinArrowShots(int[][] points) {
        if (points.length == 0) {
            return 0;
        }

        Arrays.sort(points, Comparator.comparingInt(a -> a[0]));

        var result = 1;
        var prev = points[0];

        for (var i = 1; i < points.length; i++) {
            var current = points[i];
            if (prev[1] < current[0]) {
                result++;
                prev = current;
            } else {
                prev[0] = Math.max(prev[0], current[0]);
                prev[1] = Math.min(prev[1], current[1]);
            }
        }

        return result;
    }
}