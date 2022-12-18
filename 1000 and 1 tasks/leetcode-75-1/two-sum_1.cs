public class Solution {

    public int Search (int[] nums, int x, int start) {
        var a = start;
        var b = nums.Length - 1;

        while (a <= b) {
            var m = a + (b-a)/2;
            if (nums[m] == x) {
                return m;
            }
            else if (nums[m] > x) {
                b = m - 1;
            }
            else if (nums[m] < x) {
                a = m + 1;
            }
        }

        return -1;
    }

    public int[] MapResult(int[] nums, int x, int y) {
        var res = new int[2];
        int k = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == x || nums[i] == y) {
                res[k] = i;
                k++;
            }
        }

        return res;
    }

    public int[] TwoSum(int[] nums, int target) {
        var sorted = nums.OrderBy(x => x).ToArray();

        for (int i = 0; i < nums.Length; i++) {
            var found = Search(sorted, target - sorted[i], i + 1);
            if (found >= 0) {
                return MapResult(nums, sorted[found], sorted[i]);
            }
        }

        return new int[] {};
    }
}