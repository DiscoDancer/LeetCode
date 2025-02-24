class Solution {
    public int search(int[] nums, int target) {

        var n = nums.length;

        var lapIndex = -1;
        for (int i = 0; i < nums.length - 1; i++) {
            if (nums[i] > nums[i + 1]) {
                lapIndex = i;
                break;
            }
        }

        if (lapIndex != -1) {
            var l = 0;
            var r = n-1;

            while (l < r) {
                var m = l + (r-l)/2;
                var shift = lapIndex + 1;
                var trueM = (m + shift) % n;
                if (nums[trueM] == target) {
                    return trueM;
                }
                else if (nums[trueM] < target) {
                    l = m + 1;
                }
                else if (nums[trueM] > target) {
                    r = m - 1;
                }
            }
        }

        for (int i = 0; i < nums.length; i++) {
            if (nums[i] == target) {
                return i;
            }
        }

        return -1;
    }
}