public class Solution {
    private void Rotate(int[] nums, int a, int b) {
        while (a < b) {
            var tmp = nums[a];
            nums[a] = nums[b];
            nums[b] = tmp;
            a++;
            b--;
        }
    }

    public void Rotate(int[] nums, int k) {
        var N = nums.Length;
        k = k % N;

        if (k == 0 || N == 1) {
            return;
        }

        Rotate(nums, 0, N - k - 1);
        Rotate(nums, N - k, N - 1);
        Rotate(nums, 0, N - 1);
    }
}