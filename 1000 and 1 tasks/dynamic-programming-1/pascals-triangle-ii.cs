public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var prevRow = new List<int>() {1};
        
        for (int level = 2; level <= rowIndex + 1; level++) {
            var curRow = new List<int>();

            for (int j = 0; j < level; j++) {
                if (j == 0 || j == level - 1) {
                    curRow.Add(1);
                }
                else {
                    curRow.Add(prevRow.ElementAt(j-1) + prevRow.ElementAt(j));
                }
            }

            prevRow = curRow;
        }

        return prevRow;
    }
}