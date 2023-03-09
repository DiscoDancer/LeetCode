public class Solution {
    // https://leetcode.com/problems/search-in-rotated-sorted-array/editorial/
    private int GetRotation(int[] nums) {
        var a = 0;
        var b = nums.Length - 1;

        while (a <= b) {
            var m = (b-a)/2 + a;
            if (m < nums.Length - 1 && nums[m] > nums[m+1]) {
                return m + 1;
            }
            else if (nums[m] < nums[a]){
                b = m - 1;
            }
            else {
                a = m + 1;
            }
        }

        return 0;
    }

    public int BS(int[] arr, int target, int rotation) {
        var a = 0;
        var b = arr.Length - 1;

        while (a <= b) {
            var m = (b-a)/2 + a;
            var fixedM = Rotate(m, arr.Length, rotation);
            if (arr[fixedM] == target) {
                return fixedM;
            }
            else if (arr[fixedM] < target) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }

        return -1;
    }

    private int Rotate(int index, int n, int rotation)
    {
        return (index + rotation) % n;
    }

    public int Search(int[] nums, int target) {
        var n = nums.Length;
        var rotation = GetRotation(nums);
        return BS(nums, target, rotation);
    }
}