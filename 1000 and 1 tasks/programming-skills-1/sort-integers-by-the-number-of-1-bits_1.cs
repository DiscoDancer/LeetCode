public class Solution {
    private int GetOnes(int x) {
                    var ones = 0;
            while (x > 0) {
                if (x % 2 == 1) {
                    ones++;
                }
                x = x >> 1;
            }
            return ones;
    }

    public int[] SortByBits(int[] arr) {
        Array.Sort(arr, (x,y) => {
             var xOnes = GetOnes(x);
            var yOnes = GetOnes(y);

            if (xOnes != yOnes) {
                return xOnes < yOnes ? -1 : 1;
            }

            return x < y ? -1 : 1;
        });

        return arr;
    }
}