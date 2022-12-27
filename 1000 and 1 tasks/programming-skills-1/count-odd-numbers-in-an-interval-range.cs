public class Solution {
    public int CountOdds(int low, int high) {
        var i = low;
        var res = 0;
        while (i <= high) {
            if (i % 2 == 1) {
                res++;
            }
            i++;
        }

        return res;
    }
}