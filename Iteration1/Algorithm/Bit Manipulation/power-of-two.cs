public class Solution {
    public bool IsPowerOfTwo(int n) {
        if (n <= 0) {
            return false;
        }
        
        int k = 0;
        while (n != 0) {
            if ((n & 1) == 1) {
                k++;
            }
            n = n >> 1;
        }
        
        return k == 1;
    }
}