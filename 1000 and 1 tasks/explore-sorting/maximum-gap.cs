public class Solution {
    // https://www.geeksforgeeks.org/radix-sort/
    private void RadixSort(int[] nums, int exp) {
        var output = new int[nums.Length];
        var count = new int[10];

        for (var i = 0; i < nums.Length; i++)
            count[(nums[i] / exp) % 10]++;

        for (var i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (var i = nums.Length - 1; i >= 0; i--) {
            output[count[(nums[i] / exp) % 10] - 1] = nums[i];
            count[(nums[i] / exp) % 10]--;
        }

        for (var i = 0; i < nums.Length; i++)
            nums[i] = output[i];
    }

    public int MaximumGap(int[] nums) {
        if (nums.Length == 1) {
            return 0;
        }

        var max = nums.Max();
        
        for (int exp = 1; max / exp > 0; exp *= 10)
            RadixSort(nums, exp);
        
        var result = 0;
        var prev = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            var cur = nums[i];
            result = Math.Max(cur-prev, result);
            prev = cur;
        }

        return result;
    }
}