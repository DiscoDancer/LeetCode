import java.math.BigInteger;
import java.util.*;

class Solution {

    public int[] sortedSquares(int[] nums) {
        var result = new int[nums.length];
        var firstPositiveIndex = 0;
        while (firstPositiveIndex < nums.length && nums[firstPositiveIndex] < 0) {
            firstPositiveIndex++;
        }

        var l = firstPositiveIndex - 1;
        var r = firstPositiveIndex;
        var i = 0;

        while (i < result.length) {
            // can take both
            if (l >= 0 && r < nums.length) {
                if (Math.abs(nums[l]) < Math.abs(nums[r])) {
                    result[i] = nums[l] * nums[l];
                    l--;
                } else {
                    result[i] = nums[r] * nums[r];
                    r++;
                }
            }
            else if (l >= 0) {
                result[i] = nums[l] * nums[l];
                l--;
            }
            else if (r < nums.length) {
                result[i] = nums[r] * nums[r];
                r++;
            }

            i++;
        }

        return result;
    }
}