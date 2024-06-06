public class Solution {
    // я до этого решал remove-duplicates-from-sorted-array-i
    public int RemoveDuplicates(int[] nums) {
        var j = 0;

        var prev = int.MinValue;
        var prevPrev = int.MinValue;

        for (int i = 0; i < nums.Length; i++) {
            if (prev != nums[i] || prevPrev != nums[i]) {
                nums[j++] = nums[i];
            }
            
            prevPrev = prev;
            prev = nums[i];
        }

        return j;
    }
}