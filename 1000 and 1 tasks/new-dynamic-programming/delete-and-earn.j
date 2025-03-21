import java.util.ArrayList;
import java.util.List;

// TL

class Solution {

    private int max = 0;
    private int[] nums;

    private void F(int i, int sum, List<Integer> selected) {
        if (i == nums.length) {
            max = Math.max(max, sum);
            return;
        }

        // select
        
        var canSelect = true;
        for (var x: selected) {
            if (x == nums[i] - 1 || x == nums[i] + 1 || x == nums[i]) {
                canSelect = false;
                break;
            }
        }
        if (canSelect) {
            var count = 0;
            var j = i;
            while (j < nums.length) {
                if (nums[j] == nums[i]) {
                    count++;
                }
                j++;
            }
            var gain = count * nums[i];
            var copy = new ArrayList<>(selected);
            copy.add(nums[i]);
            F(i + 1, sum + gain, copy);
        }
        
        // not select
        F(i + 1, sum, selected);
    }

    public int deleteAndEarn(int[] nums) {
        this.nums = nums;

        F(0, 0, new ArrayList<>());

        return max;
    }
}
