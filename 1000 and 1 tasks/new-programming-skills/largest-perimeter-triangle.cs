public class Solution {
    // n3 easy
    // sort + pointers = n2 3ий ходит, а 2 других от начала и конца
    public int LargestPerimeter(int[] nums) {
        var result = 0;


        Array.Sort(nums);

        for (int i = 1; i < nums.Length - 1; i++) {
            var j = i -1;
            var k = i + 1;



            while (nums[i] < nums[j] + nums[k] && nums[k] < nums[i] + nums[j] && nums[j] < nums[i] + nums[k]) {
                result = Math.Max(result, nums[i] + nums[j] + nums[k]);
                k++;
                if (k == nums.Length) {
                    break;
                }
            }
        }

        return result;
    }
}