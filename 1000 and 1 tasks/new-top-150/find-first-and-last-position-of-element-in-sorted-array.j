class Solution {

    public int[] searchRange(int[] nums, int target) {
        var n = nums.length;
        var l = 0;
        while (l < n && nums[l] != target) {
            l++;
        }
        var r = n-1;
        while (r >= 0 && nums[r] != target) {
            r--;
        }

        if (l == n) {
            return new int[] {-1, -1};
        }

        return new int[]{l,r};
    }
}