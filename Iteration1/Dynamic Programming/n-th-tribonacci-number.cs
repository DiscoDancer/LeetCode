public class Solution {
    public int Tribonacci(int n) {
        if (n <= 1) {
            return n;
        }
        
        if (n == 2) {
            return 1;
        }
        
        var a = 0; // o-th
        var b = 1; // 1-th
        var c = 1; // 2-th
        
        var res = 0;
        for (int i = 3; i <= n; i++) {
            var k1 = c;
            var k2 = b;
            c = a + b + c;
            b = k1;
            a = k2;
        }
        
        return c;
    }
}