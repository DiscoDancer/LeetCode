public class Solution {
    public int UniquePaths(int m, int n) {
        var row = new int[n];
        Array.Fill(row, 1);

        for (int i = 1; i < m; i++) {
            var newRow = new int[n];
            Array.Fill(newRow, 1);
            for (int j = 1; j < n; j++) {
                newRow[j] = row[j] + newRow[j-1];
            }
            row = newRow;
        }

        return row.Last();
    }
}