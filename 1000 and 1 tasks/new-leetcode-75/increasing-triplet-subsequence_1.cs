public class Solution {
    // иду по элементу и мне важно, есть ли слева меньше, а справа больше
    // массив минимумом и максимумов
    // мб 2 pointers
    public bool IncreasingTriplet(int[] nums) {
        var mins = new int[nums.Length];
        mins[0] = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            mins[i] = Math.Min(mins[i-1], nums[i]);
        }

        var maxs = new int[nums.Length];
        maxs[nums.Length - 1] = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--) {
            maxs[i] = Math.Max(maxs[i+1], nums[i]);
        }

        for (int i = 1; i < nums.Length - 1; i++) {
            if (mins[i-1] < nums[i] && nums[i] < maxs[i+1]) {
                return true;
            }
        }

        return false;
    }
}