import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// TL


class Solution {

    private int[] nums;
    private int result = 0;

    private void F(int sum) {
        if (sum == 0) {
            this.result++;
            return;
        }
        if (sum < 0) {
            return;
        }

        for (var i = 0; i < nums.length; i++) {
            F(sum - nums[i]);
        }
    }

    public int combinationSum4(int[] nums, int target) {
        this.nums = nums;

        F(target);

        return this.result;
    }
}
