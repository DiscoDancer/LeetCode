import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public int search(int[] nums, int target) {
        var l = 0;
        var r = nums.length - 1;

        while (l <= r) {
            var m = (r-l) / 2 + l;
            if (nums[m] == target) {
                return m;
            }
            else if (nums[m] < target) {
                l = m + 1;
            }
            else if (nums[m] > target) {
                r = m - 1;
            }
        }

        return -1;
    }
}
