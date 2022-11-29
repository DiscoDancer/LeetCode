public class Solution {
    
    public int Transform(int i, int k, int m) {
        if (i < k) {
            return i + m;
        }
        return i - k;
    }
    
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
        if (nums.Length == 1) {
            return nums[0];
        }
        
        var badIndex = FindBadIndex(nums);
        if (badIndex == -1) {
            return nums[0];
        }
        
        var n = nums.Length;
        var k = n - badIndex - 1;
        var m = n - k;
        
        var trueZero = Transform(0, k, m);
        
        return nums[trueZero];
    }
}