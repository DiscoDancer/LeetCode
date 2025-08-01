import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Solution {
    public int findMaxLength(int[] nums) {
        var result = 0;

        for (var middle = 1; middle < nums.length; middle++) {
            var l = middle - 1;
            var r = middle;

            var sum = 0;

            while (l >= 0 && r < nums.length) {
                sum += nums[l];
                sum += nums[r];

                // сумма = половине длины всегда
                if (sum * 2 == r - l + 1) {
                    result = Math.max(result, sum * 2);
                }

                l--;
                r++;
            }
        }

        return result;
    }
}