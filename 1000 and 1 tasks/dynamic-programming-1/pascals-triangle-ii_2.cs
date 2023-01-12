public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var maxLen = rowIndex + 1;
        var prevRow = new int[maxLen];
        prevRow[0] = 1;
        
        for (int level = 2; level <= rowIndex + 1; level++) {
            var prevOld = -1;
            for (int j = 0; j < level; j++) {
                var old = prevRow[j];

                if (j == 0 || j == level - 1) {
                    prevRow[j] = 1;
                }
                else {
                   prevRow[j] = prevOld + prevRow[j];
                }
                prevOld = old;
            }
        }

        return prevRow.ToList();
    }
}