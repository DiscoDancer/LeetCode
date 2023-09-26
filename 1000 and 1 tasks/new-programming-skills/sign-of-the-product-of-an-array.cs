public class Solution {
    public int ArraySign(int[] nums) {
        var sign = 1;

        foreach (var n in nums) {
            if (n == 0) {
                return 0;
            }

            sign *= n > 0 ? 1 : -1;
        }

        return sign;
    }
}