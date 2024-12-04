import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// sq
public class Solution {
    public int[] twoSum(int[] nums, int target) {

        for (var i = 0; i < nums.length; i++) {
            for (var j = i + 1; j < nums.length; j++) {
                if (nums[i] + nums[j] == target) {
                    return new int[]{i, j};
                }
            }
        }

        throw new RuntimeException("No solution found");
    }
}