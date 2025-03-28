import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {

    private int[] nums;
    private int max = 0;

    private void F(int i, int startI, int score) {
        if (i == nums.length) {
            max = Math.max(max, score);
        }
        else {
            // не взяли
            F(i + 1, startI, score);
            // взяли
            if (startI == -1 || nums[i] > nums[startI]) {
                F(i + 1, i, score + 1);
            }
        }
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;

        F(0, -1, 0);

        return this.max;
    }
}
