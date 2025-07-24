import java.math.BigInteger;
import java.util.*;

class Solution {

    public int findMaxConsecutiveOnes(int[] nums) {
        var max = 0;

        for (var i = 0; i < nums.length; i++) {
            if (nums[i] == 1) {
                var curCount = 1;
                var j = i + 1;
                while (j < nums.length && nums[j] == 1) {
                    curCount++;
                    j++;
                }
                max = Math.max(curCount, max);
                i = j - 1;
            }
        }

        return max;
    }
}