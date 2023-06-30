public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var prev = new List<int>() {1};
        var result = new List<IList<int>>() {prev};

        for (int j = 1; j < numRows; j++) {
            var cur = new List<int>();
            for (int i = 0; i < prev.Count(); i++) {
                if (i == 0) {
                    cur.Add(prev[i]);
                }
                if (i > 0) {
                    cur.Add(prev[i] + prev[i-1]);
                }
                if (i == prev.Count() - 1) {
                    cur.Add(prev[i]);
                }
            }
            prev = cur;
            result.Add(prev);
        }

        return result;
    }
}