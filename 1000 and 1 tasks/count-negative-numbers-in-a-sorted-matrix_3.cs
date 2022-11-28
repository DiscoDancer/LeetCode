public class Solution {
    // нужен второй бинарный, чтобы все не перебирать. Хотя нет
    public int CountNegatives(int[][] grid) {
        int count = 0;
        
        var i = grid.Length - 1;
        while (i >= 0 && grid[i].Last() < 0) {
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
            
            i--;
        }
        
        
        return count;
    }
}