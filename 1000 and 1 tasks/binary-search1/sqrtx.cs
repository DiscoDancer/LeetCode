public class Solution {
    // TODO решить за n^n
    // в instern я вроде b + 1 вовзращал
    public int MySqrt(int x) {
        if (x < 2) {
            return x;
        }
        
        for (int i = 1; i <= x; i++) {
            int res = i * i;
            if (res == x) {
                return i;
            } else if (res > x) {
                int max = res;
                int min = res - 1;
                if (max - x < x - min) {
                    return i + 1;
                }
                return i - 1;
            }
        }
        
        return -1;
    }
}