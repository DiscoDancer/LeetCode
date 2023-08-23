public class Solution {
    // editorial
    public int RangeBitwiseAnd(int left, int right) {
        int shift = 0;
        // find the common 1-bits
        while (left < right) {
          left >>= 1;
          right >>= 1;
          ++shift;
        }
        return left << shift;
    }
}