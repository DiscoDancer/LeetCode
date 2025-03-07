class Solution {
    public int mySqrt(int x) {

        long l = 0;
        long r = x;

        while (l <= r) {
            long m = l + (r - l) / 2;
            if (m*m == x) {
                return (int)m;
            }
            else if (m*m > x && (m-1)*(m-1) < x) {
                return (int)m-1;
            }
            else if (m*m < x) {
                l = m + 1;
            }
            else {
                r = m - 1;
            }
        }

        return -1;
    }
}