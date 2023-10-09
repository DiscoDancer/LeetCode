public class Solution {
    // иду по элементу и мне важно, есть ли слева меньше, а справа больше
    // массив минимумом и максимумов
    // мб 2 pointers
    public bool IncreasingTriplet(int[] nums) {
        var maxs = new int[nums.Length];
        maxs[nums.Length - 1] = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--) {
            maxs[i] = Math.Max(maxs[i+1], nums[i]);
        }

        var min = nums[0]; 
        for (int i = 1; i < nums.Length - 1; i++) {
            if (min < nums[i] && nums[i] < maxs[i+1]) {
                return true;
            }
            min = Math.Min(min, nums[i]); 
        }

        return false;
    }
}