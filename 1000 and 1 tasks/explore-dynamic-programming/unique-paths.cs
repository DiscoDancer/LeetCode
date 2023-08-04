public class Solution {
    // сходу составил табличку, но можно было бы начать с top down
    public int UniquePaths(int m, int n) {

        var table = new int[m, n];
        // table[0,0] = 1;

        for (var x = 0; x < m; x++) {
            for (var y = 0; y < n; y++) {
                if (x == 0 && y == 0) {
                    table[x,y] = 1;
                }
                else if (x == 0) {
                    table[x,y] = table[x,y-1]; 
                }
                else if (y == 0) {
                    table[x,y] = table[x-1, y];
                }
                else {
                    table[x,y] = table[x,y-1] + table[x-1, y];
                }
            }
        }

        return table[m-1,n-1];
    }
}