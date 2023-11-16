public class Solution {
    public int[] CountBits(int n) {
        var table = new int[n+1];
        table[0] = 0;

        for (int i = 1; i <= n; i++) {
            table[i] = i % 2 + table[i >> 1];
        }

        return table;
    }
}