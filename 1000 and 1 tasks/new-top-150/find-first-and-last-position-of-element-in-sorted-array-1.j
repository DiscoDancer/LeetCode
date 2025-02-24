class Solution {

    public int findLeft(int[] nums, int target) {
        var n = nums.length;
        var l = 0;
        var r = n-1;
        // >= потому массив может быть [1]
        while (l <= r) {
            var m = l + (r-l)/2;
            if (nums[m] == target && (m == 0 || nums[m-1] != target)) {
                return m;
            }
            if (nums[m] < target) {
                l = m+1;
            }
            else if (nums[m] > target) {
                r = m - 1;
            }
            else if (nums[m] == target) {
                r = m - 1;
            }
        }

        return -1;
    }

    public int findRight(int[] nums, int target) {
        var n = nums.length;
        var l = 0;
        var r = n-1;
        // >= потому массив может быть [1]
        while (l <= r) {
            var m = l + (r-l)/2;
            if (nums[m] == target && (m == n-1 || nums[m+1] != target)) {
                return m;
            }
            if (nums[m] < target) {
                l = m+1;
            }
            else if (nums[m] > target) {
                r = m - 1;
            }
            else if (nums[m] == target) {
                l = m + 1;
            }
        }

        return -1;
    }

    public int[] searchRange(int[] nums, int target) {
        var n = nums.length;
        var l = findLeft(nums, target);
        var r = findRight(nums, target);

        if (l == n) {
            return new int[] {-1, -1};
        }

        return new int[]{l,r};
    }
}