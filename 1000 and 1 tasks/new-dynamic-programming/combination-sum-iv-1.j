import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public int combinationSum4(int[] nums, int target) {
        var table = new int[target + 1];
        table[0] = 1;

        for (var sum = 1; sum <= target; sum++) {
            for (var i = 0; i < nums.length; i++) {
                if (sum - nums[i] >= 0) {
                    table[sum] += table[sum - nums[i]];
                }
            }
        }

        return table[target];
    }
}
