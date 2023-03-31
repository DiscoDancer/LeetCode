public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var length = nums.Length;

        for (int i = 0; i < length; i++) {
            if (nums[i] == val) {
                for (int j = i; j < length - 1; j++) {
                    nums[j] = nums[j+1];
                }
                length--;
                if (nums[i] == val) {
                    i--;
                }
            }
        }

        return length;
    }
}