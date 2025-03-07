class Solution {
    public int mySqrt(int x) {

        for (int i = 0; i <= x; i++) {
            var longI = (long) i;
            if (longI * longI == x) {
                return i;
            } else if (longI * longI > x) {
                return i - 1;
            }
        }

        return 0;
    }
}