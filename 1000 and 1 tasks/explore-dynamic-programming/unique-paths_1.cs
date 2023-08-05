public class Solution {
    // сходу составил табличку, но можно было бы начать с top down
    public int UniquePaths(int m, int n) {
        var row = new int[n];
        Array.Fill(row, 1);

        for (var x = 1; x < m; x++) {
            for (var y = 0; y < n; y++) {
                if (y == 0) {
                    // table[x,y] = table[x-1, y];
                }
                else {
                    row[y] = row[y-1] + row[y];
                }
            }
        }

        return row.Last();
    }
}