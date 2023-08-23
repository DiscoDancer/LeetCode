public class Solution {
    public int[] CountBits(int n) {
        var result = new int[n+1];

        for (int i = 1; i <= n; i++) {
            var x = i;
            while (x > 0) {
                if (x % 2 == 1) {
                    result[i]++;
                }
                x = x/2;
            }
        }

        return result;
    }
}