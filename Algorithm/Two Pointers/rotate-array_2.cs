using System.Linq;

public class Solution {
    
    public static void Reverse(int[] nums, int i, int j)
    {
        while (i < j)
        {
            int k = nums[i];
            nums[i] = nums[j];
            nums[j] = k;
            i++;
            j--;
        }
    }
    
    public void Rotate(int[] nums, int k) {
        if (nums.Length == 1) {
            return;
        }
        
        var n = nums.Length;
        var kFixed = k % n;
        var r = n - kFixed;
        var j = 0;
        
        Reverse(nums, 0, r - 1);
        Reverse(nums, r, n - 1);
        Reverse(nums, 0, n - 1);
    }
}