public class Solution {
    public bool IsPowerOfTwo(int n) {
        if (n <= 0) {
            return false;
        }

        while (n > 0) {
            if (n == 1) {
                return true;
            }
            if ( (n & 1) != 0) {
                return false;
            }
            n = n >> 1;
        }

        throw new Exception();
    }
}