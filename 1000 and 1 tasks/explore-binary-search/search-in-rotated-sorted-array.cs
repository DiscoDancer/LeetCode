public class Solution {
    public int FindShift(int[] nums) {
        var L = 0;
        var R = nums.Length - 1;

        while (L <= R) {
            var M = L + (R-L)/2;

            if (M == nums.Length - 1 || nums[M] > nums[M+1]) {
                return M;
            }
            if (nums[M] < nums[L]) {
                R = M - 1;
            }
            else {
                L = M + 1;
            }
        }

        return -1;
    }
    
    public int Search(int[] nums, int target)
    {
        var N = nums.Length;
        var shift = FindShift(nums);
        var L = (shift + 1) % N;
        var R = (L + N - 1) % N;

        var l = 0;
        var r = nums.Length - 1;

        while (l <= r)
        {
            var m = l + (r - l) / 2;
            var fixedM = (m + shift + 1) % nums.Length;
            if (nums[fixedM] == target)
            {
                return fixedM;
            }

            if (nums[fixedM] < target)
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return -1;
    }
}