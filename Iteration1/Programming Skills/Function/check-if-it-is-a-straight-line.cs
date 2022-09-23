public class Solution {
    public bool CheckStraightLine(int[][] coordinates) {
        var p1 = coordinates[0];
        var p2 = coordinates[1];
        int[] p3;
        
        for (var i = 2; i < coordinates.Length; i++) {
            p3 = coordinates[i];
            double a = ((double)(p3[0] - p1[0]) ) / ( (double)(p2[0] - p1[0]));
            double b = ((double)(p3[1] - p1[1]) ) / ( (double)(p2[1] - p1[1]));
            
            if (Math.Abs(a - b) > 0.0001) {
                return false;
            }
            
            p1 = p2;
            p2 = p3;
        }
        
        return true;
    }
}