public class Solution {
    public static int FindBadIndex(int[] nums) {
        var a = 0;
        var b = nums.Length - 1;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            if (m < nums.Length - 1 && nums[m] > nums[m+1]) {
                return m;
            }
            else if (nums[a] <= nums[m]) {
                a = m + 1;
            }
            else if (nums[a] > nums[m]) {
                b = m - 1;
            }
        }
        
        return -1;
    }
    
    public int FindMin(int[] nums) {
        var badIndex = FindBadIndex(nums);
        if (badIndex == -1) {
            return nums[0];
        }
        
        return nums[badIndex + 1];
    }
}