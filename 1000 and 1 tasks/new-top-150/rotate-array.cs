
// никакой магии, просто либо помшнишь либо нет
public class Solution {
    private void Rotate(int[] nums, int l, int r) {
        while (l < r) {
            var tmp = nums[l];
            nums[l] = nums[r];
            nums[r] = tmp;
            l++;
            r--;
        }
    }

    public void Rotate(int[] nums, int k) {
        var n = nums.Length;
        k = k % n;

        var n1 = n - k;
        var n2 = k;

        Rotate(nums, 0, n1-1);
        Rotate(nums, n1, n-1);
        Rotate(nums, 0,n-1);
    }
}