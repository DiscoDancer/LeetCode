import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {

    private int[] nums;
    private int F(int i, int startI) {
        if (i == nums.length) {
            return 0;
        }
        else {
            var skip = F(i + 1, startI);
            var take = 0;
            if (startI == -1 || nums[i] > nums[startI]) {
                take = 1 + F(i + 1, i);
            }
            return Math.max(skip, take);
        }
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;

        return F(0, -1);
    }
}
