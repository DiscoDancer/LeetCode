public class Solution {
    // заменить на массивы макс длины
    public IList<int> GetRow(int rowIndex) {
        var maxLen = rowIndex + 1;
        var prevRow = new int[maxLen];
        prevRow[0] = 1;
        
        for (int level = 2; level <= rowIndex + 1; level++) {
            var curRow = new int[maxLen];

            for (int j = 0; j < level; j++) {
                if (j == 0 || j == level - 1) {
                    curRow[j] = 1;
                }
                else {
                   curRow[j] = prevRow[j-1] + prevRow[j];
                }
            }

            prevRow = curRow;
        }

        return prevRow.ToList();
    }
}