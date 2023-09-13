public class Solution {
    public bool IsPerfectSquare(int num) {
        long l = 0;
        long r = num; 

        while (l <= r) {
            var m = l + (r-l)/2;
            if (m*m == num) {
                return true;
            }
            else if (m*m < num) {
                l = m+1;
            }
            else {
                r = m - 1;
            }
        }

        return false;
    }
}