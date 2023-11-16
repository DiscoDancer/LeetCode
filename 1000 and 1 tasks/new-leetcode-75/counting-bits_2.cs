public class Solution {
    public int[] CountBits(int n) {
        if (n == 0) {
            return new int[] {0};
        }
        var table = new int[n+1];
        table[0] = 0;
        table[1] = 1;

        for (int i = 2; i <= n; i++) {
            table[i] = i % 2 + table[i >> 1];
        }

        return table;
    }
}