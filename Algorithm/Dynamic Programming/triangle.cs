public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var arr = triangle.ToArray();
        
        if (arr.Length == 1) {
            return arr[0].First();
        }
        
        // at least 2 levels here
        var cur = arr[0].ToArray();
        int[] next = null;
        
        for (int i = 1; i < arr.Length; i++) {
            next = arr[i].ToArray();
            
            for (int j = 0; j < next.Length; j++) {
                var min = int.MaxValue;
                
                if (j > 0 && j - 1 < cur.Length) {
                    min = Math.Min(min, cur[j - 1]);
                }
                if (j < cur.Length) {
                    min = Math.Min(min, cur[j]);
                }
                
                next[j] += min;
            }
            
            cur = next;
        }
        
        return next.Min();
    }
}