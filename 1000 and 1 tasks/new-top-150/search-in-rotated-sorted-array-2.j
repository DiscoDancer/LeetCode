class Solution {

    public int findLapIndex(int[] nums) {
        var n = nums.length;

        var l = 0;
        var r = n - 1;

        while (l < r) {
            var m = l + (r-l)/2;
            if (m == n-1) {
                return -1;
            }
            if (nums[m] > nums[m+1]) {
                return m;
            }
            // если это условие выполняется, нам нечего делать справа
            if (nums[m] < nums[r]) {
                r = m - 1;
            }
            // иначе слева
            else {
                l = m +1;
            }
        }

        return -1;
    }

    public int search(int[] nums, int target) {

        var n = nums.length;

        var lapIndex = findLapIndex(nums);

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