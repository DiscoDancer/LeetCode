public class Solution {
    // в instern я вроде b + 1 вовзращал
    // n*n = too slow
    public int MySqrt(int x) {
        if (x < 2) {
            return x;
        }
        
        long xx = x;
        
        for (int i = 1; i <= xx; i++) {
            long res = i * i;
            if (res == xx) {
                return i;
            } else if (res > xx) {
                return i - 1;
            }
        }
        
        return -1;
    }
}