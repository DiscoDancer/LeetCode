public class Solution {

    private bool Check3(int[] a, int[] b, int[] c) {
        if (a[0] == b[0] && b[0] == c[0] || a[1] == b[1] && b[1] == c[1] ) {
            return true;
        }
        var one = (double)(c[0] - a[0]) / (double)(b[0] - a[0]);
        var two = (double)(c[1] - a[1]) / (double)(b[1] - a[1]);

        var diff = Math.Abs(one - two);
        var prec = 0.0001;

        return diff < prec;
    }

    public bool CheckStraightLine(int[][] coordinates) {
        if (coordinates.Length == 2) {
            return true;
        }

        var a = coordinates[0];
        var b = coordinates[1];
        int[] c;

        for (int i = 2; i < coordinates.Length; i++) {
            c = coordinates[i];
            if (!Check3(a,b,c)) {
                return false;
            }

            a = b;
            b = c;
        }

        return true;
    }
}