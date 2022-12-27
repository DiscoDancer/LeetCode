public class Solution {
    public int HammingWeight(uint n) {
        var res = 0;
        while (n > 0) {
            res += n % 2 == 1 ? 1 : 0;
            n = n >> 1;
        }

        return res;
    }
}