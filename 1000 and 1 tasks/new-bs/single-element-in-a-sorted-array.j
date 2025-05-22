import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;

class Solution {

    public int singleNonDuplicate(int[] nums) {

        var l = 0;
        var r = nums.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            // has both neighbors
            if (m > 0 && m < nums.length - 1 && nums[m] != nums[m - 1] && nums[m] != nums[m + 1]) {
                return nums[m];
            }
            // no neighbors
            if (m == 0 && m == nums.length - 1) {
                return nums[m];
            }
            // has 1 neighbor
            if (m == 0 && nums[m] != nums[m + 1]) {
                return nums[m];
            }
            // has 1 neighbor
            if (m == nums.length - 1 && nums[m] != nums[m - 1]) {
                return nums[m];
            }



            var halfLength = r-m;
            // base case
            if (halfLength == 1) {
                if (nums[m] == nums[l]) {
                    return nums[r];
                }
                return nums[l];
            }
            if (halfLength % 2 == 1) {
                if (m > 0 && nums[m] == nums[m - 1]) {
                    l = m + 1;
                } else {
                    r = m - 1;
                }
            }
            else if (halfLength % 2 == 0) {
                if (m > 0 && nums[m] == nums[m - 1]) {
                    r = m;
                } else {
                    l = m;
                }
            }
        }

        return -1;
    }
}
