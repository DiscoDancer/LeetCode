public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var res = new List<IList<int>>() {new List<int>() {1}};
        
        var prevLevel = new int[] {1};
        for (var n = 2; n <= numRows; n++) {
            var newLevel = new int[n];
            
            for (int i = 0; i < n; i++) {
                if (i == 0 || i == n - 1) {
                    newLevel[i] = 1;
                }
                else {
                    newLevel[i] = prevLevel[i-1] + prevLevel[i];
                }
            }
            
            res.Add(newLevel.ToList());
            prevLevel = newLevel;
        }
        
        return res;
    }
}