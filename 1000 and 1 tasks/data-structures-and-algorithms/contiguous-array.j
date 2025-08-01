import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Solution {
    // TL
    public int findMaxLength(int[] nums) {
        var result = 0;

        for (var middle = 1; middle < nums.length; middle++) {
            var l = middle - 1;
            var r = middle;

            var count0 = 0;
            var count1 = 0;

            while (l >= 0 && r < nums.length) {
                if (nums[l] == 0) count0++;
                if (nums[l] == 1) count1++;
                if (nums[r] == 0) count0++;
                if (nums[r] == 1) count1++;

                if (count0 == count1) {
                    result = Math.max(result, count0 + count1);
                }

                l--;
                r++;
            }
        }

        return result;
    }
}