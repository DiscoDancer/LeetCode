public class Solution {
    public int HammingWeight(uint n) {
        uint res = 0;
        uint one = 1;
        while (n > 0) {
            res += n & one;
            n = n >> 1;
        }

        return (int)res;
    }
}