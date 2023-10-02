public class Solution {
    public bool CheckStraightLine(int[][] coordinates) {
        if (coordinates.Length == 2) {
            return true;
        }

        var dx = coordinates[1][0] - coordinates[0][0];
        var dy = coordinates[1][1] - coordinates[0][1];

        for (int i = 2; i < coordinates.Length; i++) {
            var x = coordinates[i][0];
            var y = coordinates[i][1];

            if (dx * (y - coordinates[1][1]) != dy * (x - coordinates[1][0])) {
                return false;
            }
        }

        return true;
    }
}