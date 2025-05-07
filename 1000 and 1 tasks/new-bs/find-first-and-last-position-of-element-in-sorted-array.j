class Solution {

    private int findFirst(int[] nums, int target) {
        var first = -1;
        var l = 0;
        var r = nums.length - 1;
        while (l <= r) {
            var m = l + (r - l) / 2;
            if (nums[m] == target) {
                if (m == 0 || nums[m - 1] < target) {
                    first = m;
                    break;
                }
                r = m - 1;
            }
            else if (nums[m] > target) {
                r = m - 1;
            }
            else if (nums[m] < target) {
                l = m + 1;
            }
        }
        return first;
    }

    private int findLast(int[] nums, int target) {
        var last = -1;
        var l = 0;
        var r = nums.length - 1;
        while (l <= r) {
            var m = l + (r - l) / 2;
            if (nums[m] == target) {
                if (m == nums.length - 1 || nums[m + 1] > target) {
                    last = m;
                    break;
                }
                l = m + 1;
            }
            else if (nums[m] > target) {
                r = m - 1;
            }
            else if (nums[m] < target) {
                l = m + 1;
            }
        }
        return last;
    }

    public int[] searchRange(int[] nums, int target) {
        return new int[] {findFirst(nums, target), findLast(nums, target)};
    }
}
