public class Solution {
    public int[] SortArray(int[] nums) {
        if (nums.Length <= 1) {
            return nums;
        }

        var middle = nums.Length / 2;
        var left = SortArray(nums.Take(middle).ToArray());
        var right = SortArray(nums.Skip(left.Length).ToArray());

        return Merge(left, right);
    }

    public int[] Merge(int[] left, int[] right) {
        var result = new int[left.Length + right.Length];
        var i = 0;

        var l = 0;
        var r = 0;

        while (l < left.Length && r < right.Length) {
            if (left[l] < right[r]) {
                result[i++] = left[l++];
            }
            else {
                result[i++] = right[r++];
            }
        }

        while (l < left.Length) {
            result[i++] = left[l++];
        }

        while (r < right.Length) {
            result[i++] = right[r++];
        }

        return result;
    }
}