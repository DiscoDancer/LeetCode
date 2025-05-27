import java.util.*;

// TL

class Solution {

    public int triangleNumber(int[] nums) {

        var result = 0;

        for (var i = 0; i < nums.length; i++) {
            for (var j = i + 1; j < nums.length; j++) {
                for (var k = j + 1; k < nums.length; k++) {
                    if (nums[i] + nums[j] > nums[k] &&
                        nums[i] + nums[k] > nums[j] &&
                        nums[j] + nums[k] > nums[i]) {
                        result++;
                    }
                }
            }
        }

        return result;
    }
}
