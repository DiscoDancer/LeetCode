import java.util.Arrays;
import java.util.Collections;

class Solution {

    public int findKthLargest(int[] nums, int k) {
        // в терминах индекса
        k = k -1;

        Arrays.sort(nums);

        return nums[nums.length - k - 1];
    }
}