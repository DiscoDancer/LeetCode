public class Solution {
    private int F(int n) {
        if (n == 0) {
            return 0;
        }
        if (n == 1) {
            return 1;
        }
        return (n % 2) + F(n >> 1);
    }
    
    public int[] CountBits(int n) {
        var result = new int[n+1];
        for (int i = 0; i <= n; i++) {
            result[i] = F(i);
        }
        return result;
    }
}