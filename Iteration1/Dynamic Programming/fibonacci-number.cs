public class Solution {
    public int Fib(int n) {
        if (n <= 1) {
            return n;
        }
        
        var cur = 1;
        var prev = 0;
        
        for (int i = 2; i <= n; i++) {
            var k = cur;
            cur = prev + cur;
            prev = k;
        }
        
        return cur;
    }
}