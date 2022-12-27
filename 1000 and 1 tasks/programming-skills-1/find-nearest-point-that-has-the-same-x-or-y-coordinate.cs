public class Solution {
    public int NearestValidPoint(int x, int y, int[][] points) {

        var minDistance = (double?) null;
        var index = -1;

        for (int i = 0; i < points.Length; i++) {
            var p = points[i];
            var xx = p[0];
            var yy = p[1];
            
            if (!(xx == x || yy == y)) {
                continue;
            }

            var distance = Math.Sqrt(Math.Pow(x-xx,2) + Math.Pow(y-yy, 2));
            if (minDistance == null || distance < minDistance.Value) {
                minDistance = distance;
                index = i;
            }
        }

        return index;
    }
}