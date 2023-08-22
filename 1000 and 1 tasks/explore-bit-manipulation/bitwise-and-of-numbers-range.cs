public class Solution {
    // TL
    public int RangeBitwiseAnd(int left, int right) {
        var x = left;
        var result = left;

        while (x <= right) {
            result = result & x;
            x++;
        }

        return result;
    }
}