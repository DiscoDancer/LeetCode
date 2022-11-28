public class Solution {
    // чуть умнее будет идти от конца строки
    public int CountNegatives(int[][] grid) {
        int count = 0;
        for (int i = 0; i < grid.Length; i++) {
            var j = grid[0].Length - 1;
            while (j >= 0 && grid[i][j] < 0) {
                j--;
                count++;
            }
        }
        
        return count;
    }
}