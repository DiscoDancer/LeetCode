public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var RowsCount = triangle.Count();
        var prevRow = new int[RowsCount];
        prevRow[0] = triangle.First().First();
        for (var row = 1; row < RowsCount; row++) {
            var ColsCount = row + 1;
            var curRow = new int[ColsCount];
            for (var col = 0; col < ColsCount; col++) {
                if (col == 0) {
                    curRow[col] = prevRow[col] + triangle[row][col];
                }
                else if (col == ColsCount - 1) {
                    curRow[col] = prevRow[col - 1] + triangle[row][col];
                }
                else {
                    curRow[col] = Math.Min(prevRow[col - 1], prevRow[col]) + triangle[row][col];
                }
            }
            prevRow = curRow;
        }

        return prevRow.Min();
    }
}