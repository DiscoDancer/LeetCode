class Solution {

    public int findMinIndex(int[] nums) {
        var n = nums.length;

        var l = 0;
        var r = n - 1;

        while (l <= r) {
            var m = l + (r-l)/2;
            if (m > 0 && nums[m-1] > nums[m]) {
                return m;
            }
            if (nums[m] < nums[r]) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return 0;
    }

    public int findMin(int[] nums) {
        return nums[findMinIndex(nums)];
    }
}