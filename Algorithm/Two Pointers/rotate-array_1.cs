using System.Linq;

// naive

public class Solution {
    public void Rotate(int[] nums, int k) {
        if (nums.Length == 1) {
            return;
        }
        
        var n = nums.Length;
        var kFixed = k % n;
        var r = n - kFixed;
        var j = 0;
        
        var arr2 = new int[n];
        
        for (int i = r; i < n; i++) {
            arr2[j++] = nums[i];
        }
        for (int i = 0; i < r; i++) {
            arr2[j++] = nums[i];
        }
        for (int i = 0; i < n; i++) {
            nums[i] = arr2[i];
        }
    }
}