public class Solution {
    private int[] GetNumbers(int[] nums, int target) {
        nums = nums.OrderBy(x => x).ToArray();

        var L = 0;
        var R = nums.Length - 1;

        while (L < R) {
            var sum = nums[L] + nums[R];
            if (sum == target) {
                return new int [] {nums[L], nums[R]};
            }
            else if (sum < target) {
                L++;
            }
            else if (sum > target) {
                R--;
            }
        }

        return null;
    } 

    public int[] TwoSum(int[] nums, int target) {
        var result = GetNumbers(nums, target);
        if (result == null) {
            return null;
        }

        int? l = null;
        int? r = null;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == result[0] || nums[i] == result[1]) {
                if (l == null) {
                    l = i;
                }
                else {
                    r = i;
                    break;
                }
            }
        }

        return new int[] {l.Value, r.Value};
    }
}