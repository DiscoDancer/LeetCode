public class Solution {
    // reverse L, reverse R, reverse LR
    // но только бьется наоборот, поэтому var m = nums.Length - k;
    public void Rotate(int[] nums, int k) {
        k = k % nums.Length;
        
        if (k == 0) {
            return;
        }

        var m = nums.Length - k;

        var l = 0;
        var r = m-1;

        while (l < r) {
            var tmp = nums[l];
            nums[l] = nums[r];
            nums[r] = tmp;
            l++;
            r--;
        }

        l = m;
        r = nums.Length - 1;
        while (l < r) {
            var tmp = nums[l];
            nums[l] = nums[r];
            nums[r] = tmp;
            l++;
            r--;
        }

        l = 0;
        r = nums.Length - 1;
        while (l < r) {
            var tmp = nums[l];
            nums[l] = nums[r];
            nums[r] = tmp;
            l++;
            r--;
        }
    }
}