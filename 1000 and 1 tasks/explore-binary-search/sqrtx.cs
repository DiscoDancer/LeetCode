public class Solution {
    // TL
    public int MySqrt(int x) {
        for (int i = 0; i <= x; i++) {
            if (i*i == x) {
                return i;
            }
            else if (i*i > x) {
                return i-1;
            }
        }

        return -1;
    }
}