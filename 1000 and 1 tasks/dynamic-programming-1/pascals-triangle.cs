public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var prevRow = new List<int>() {1};
        var res =  new List<IList<int>>() {prevRow};
        if (numRows == 1) {
            return res;
        }
      

        for (int level = 2; level <= numRows; level++) {
            var curRow = new List<int>();

            for (int j = 0; j < level; j++) {
                if (j == 0 || j == level - 1) {
                    curRow.Add(1);
                }
                else {
                    curRow.Add(prevRow.ElementAt(j-1) + prevRow.ElementAt(j));
                }
            }

            res.Add(curRow);
            prevRow = curRow;
        }

        return res;
    }
}