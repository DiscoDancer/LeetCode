import java.util.ArrayList;
import java.util.List;

class Solution {
    public List<String> summaryRanges(int[] nums) {
        var result = new ArrayList<String>();
        var left = 0;
        while (left < nums.length) {
            var right = left;
            while (right + 1 < nums.length && nums[right + 1] == nums[right] + 1) {
                right++;
            }
            if (right > left) {
                result.add(nums[left] + "->" + nums[right]);
            } else {
                result.add(String.valueOf(nums[left]));
            }

            left = right + 1;
        }

        return result;
    }
}