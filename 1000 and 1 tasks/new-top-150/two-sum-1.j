import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

public class Solution {

    private int indexOf1(int[] nums, int target) {
        for (var i = 0; i < nums.length; i++) {
            if (nums[i] == target) {
                return i;
            }
        }

        throw new RuntimeException("No solution found");
    }

    private int indexOf2(int[] nums, int target) {
        var count = 0;
        for (var i = 0; i < nums.length; i++) {
            if (nums[i] == target) {
                count++;
            }
            if (count == 2) {
                return i;
            }
        }

        throw new RuntimeException("No solution found");
    }

    public int[] twoSum(int[] nums, int target) {
        int[] original = Arrays.copyOf(nums, nums.length);
        Arrays.sort(nums);

        var l = 0;
        var r = nums.length - 1;

        while (l < r) {
            var sum = nums[l] + nums[r];

            if (sum == target) {
                var lIndex = indexOf1(original, nums[l]);
                var rIndex = nums[l] == nums[r] ? indexOf2(original, nums[r]) : indexOf1(original, nums[r]);
                return new int[]{lIndex, rIndex};
            }

            if (sum < target) {
                l++;
            } else {
                r--;
            }
        }

        throw new RuntimeException("No solution found");
    }
}