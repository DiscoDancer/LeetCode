public class Solution {
    public int NearestValidPoint(int x, int y, int[][] points) {
        var min = int.MaxValue;
        var minIndex = -1;
        
        for (var i = 0; i < points.Length; i++) {
            var p = points[i];
            var pX = p[0];
            var pY = p[1];
            
            if (pX == x || pY == y) {
                var d = Math.Abs(pX - x) + Math.Abs(pY - y);
                
                if (d < min) {
                    min = d;
                    minIndex = i;
                }
            }
        }
        
        return minIndex;
    }
}