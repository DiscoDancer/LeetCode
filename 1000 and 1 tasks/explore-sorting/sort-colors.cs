public class Solution {
    public void SortColors(int[] nums) {
        var zeroes = 0;
        var ones = 0;

        foreach (var n in nums) {
            if (n == 0) zeroes++;
            if (n == 1) ones++;
        }

        var i = 0;

        for (var j = 0; j < zeroes; j++) {
            nums[i] = 0;
            i++;
        }

        for (var j = 0; j < ones; j++) {
            nums[i] = 1;
            i++;
        }

        for (; i < nums.Length; i++) {
            nums[i] = 2;
        }
    }
}