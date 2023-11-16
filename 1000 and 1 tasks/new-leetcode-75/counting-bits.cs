public class Solution {
    private int F(int n) {
        var result = 0;
        while (n > 0) {
            result += n % 2;
            n = n >> 1;
        }

        return result;
    }
    
    // passes
    public int[] CountBits(int n) {
        var result = new int[n+1];
        for (int i = 0; i <= n; i++) {
            result[i] = F(i);
        }
        return result;
    }
}