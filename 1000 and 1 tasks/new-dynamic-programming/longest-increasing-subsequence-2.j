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
            if (nums[i] > nums[startI]) {
                take = 1 + F(i + 1, i);
            }
            return Math.max(skip, take);
        }
    }

    public int lengthOfLIS(int[] nums) {
        var extraNums = new int[nums.length + 1];
        for (int i = 0; i < nums.length; i++) {
            extraNums[i+1] = nums[i];
        }
        extraNums[0] = Integer.MIN_VALUE;

        this.nums = extraNums;

        var table = new int[extraNums.length + 1][extraNums.length + 1];

        for (var i = extraNums.length; i >= 0; i--) {
            for (var startI = extraNums.length - 1; startI >= 0; startI--) {
                if (i == extraNums.length) {
                    table[i][startI] = 0;
                }
                else {
                    var skip = table[i + 1][startI];
                    var take = 0;
                    if (extraNums[i] > extraNums[startI]) {
                        take = 1 + table[i + 1][i];
                    }
                    table[i][startI] = Math.max(skip, take);
                }
            }
        }

        return table[0][0];
    }
}
