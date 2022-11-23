public class Solution {
    public int MySqrt(int x) {
        if (x < 2) {
            return x;
        }
        
        var a = 1;
        var b = x;
        
        while (a <= b) {
            long m = a + (b-a)/2;
            long mm = m*m;
            if (mm == x) {
                return (int)m;
            }
            else if (mm < x) {
                a = (int)m + 1;
            }
            else if (mm > x) {
                b = (int)m - 1;
            }
        }
        
        return b;
        
        
//         long xx = x;
        
//         for (int i = 1; i <= xx; i++) {
//             long res = i * i;
//             if (res == xx) {
//                 return i;
//             } else if (res > xx) {
//                 return i - 1;
//             }
//         }
        
//         return -1;
    }
}