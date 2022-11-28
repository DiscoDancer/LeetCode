public class Solution {
    public int CountNegatives(int[][] grid) {
        int count = 0;
        for (int i = 0; i < grid.Length; i++) {
            var arr = grid[i];
            
            var a = 0;
            var b = arr.Length - 1;
            
            while (a <= b) {
                var m = a + (b-a)/2;
                if (arr[m] >= 0) {
                    a = m + 1;
                }
                else if (arr[m] < 0) {
                    b = m - 1;
                }
            }
            count += (arr.Length - a);
        }
        
        return count;
    }
}