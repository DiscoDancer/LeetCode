public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var prev = new List<int>() {1};

        for (int i = 1; i <= rowIndex; i++) {
            var cur = new List<int>();
            for (int j = 0; j < i + 1; j++) {
                if (j == 0 || j == i) {
                    cur.Add(1);
                }
                else {
                    cur.Add(prev[j-1] + prev[j]);
                }
            }
            prev = cur;
        }

        return prev;
    }
}