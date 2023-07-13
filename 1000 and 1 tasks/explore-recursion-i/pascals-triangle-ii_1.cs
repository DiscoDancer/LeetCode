public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var row = new int[rowIndex + 1];
        row[0] = 1;

        for (int i = 1; i <= rowIndex; i++) {
            var prev = 0;
            for (int j = 0; j < i + 1; j++) {
                var cur = row[j];
                if (j == 0 || j == i) {
                    row[j] = 1;
                }
                else {
                    row[j] = prev + row[j];
                }
                prev = cur;
            }
        }

        return row;
    }
}