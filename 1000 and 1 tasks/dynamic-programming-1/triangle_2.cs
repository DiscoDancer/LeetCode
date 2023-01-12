public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var RowsCount = triangle.Count();

        var prevRow = new int[RowsCount];
        prevRow[0] = triangle.First().First();

        for (var row = 1; row < RowsCount; row++) {
            var ColsCount = row + 1;
            var prevOld = -1;
            for (var col = 0; col < ColsCount; col++) {
                var old = prevRow[col];
                if (col == 0) {
                    prevRow[col] = prevRow[col] + triangle[row][col];
                }
                else if (col == ColsCount - 1) {
                    prevRow[col] = prevOld + triangle[row][col];
                }
                else {
                    prevRow[col] = Math.Min(prevOld, prevRow[col]) + triangle[row][col];
                }

                prevOld = old;
            }
        }

        return prevRow.Min();
    }
}