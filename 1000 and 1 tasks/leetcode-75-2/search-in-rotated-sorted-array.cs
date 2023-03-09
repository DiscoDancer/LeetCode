public class Solution {
    private int GetRotation(int[] nums) {
        var n = nums.Length;

        // todo find rotation
        var prev = nums[0];
        for (int i = 1; i < n; i++) {
            var cur = nums[i];
            if (prev > cur) {
                return i;
            }
            prev = cur;
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