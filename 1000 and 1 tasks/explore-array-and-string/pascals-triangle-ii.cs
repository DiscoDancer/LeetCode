public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var prev = new List<int>() {1};

        for (int j = 1; j < rowIndex + 1; j++) {
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
        }

        return prev;
    }
}