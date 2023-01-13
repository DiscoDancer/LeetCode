public class Solution {
    public int UniquePaths(int m, int n) {
        var prev = new int[n];
        for (int i = 0; i < n; i++) {
            prev[i] = 1;
        }

        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                prev[j] = prev[j] + prev[j-1];
            }
        }

        return prev.Last();
    }
}