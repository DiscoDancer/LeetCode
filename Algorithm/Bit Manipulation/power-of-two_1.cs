public class Solution {
    public bool IsPowerOfTwo(int n) {
        if (n == 0) return false;
        long x = (long) n;
        return (x & (-x)) == x;
    }
}