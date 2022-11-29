public class Solution {
    
    /*
        Roadmap:
            + transform + bin search + n
            - transform + bin search + bin search
    */
    
    public static int Transform(int i, int k, int m)
    {
        if (i < k)
        {
            return i + m;
        }
        return i - k;
    }
    
    // найти k и применить его
    // K можно искать как гору
    public int Search(int[] nums, int target) {
        if (nums.Length == 1) {
            if (nums[0] == target) {
                return 0;
            }
            
            return -1;
        }
        
        var badIndex = -1;
        for (int i = 0; badIndex < 0 && i < nums.Length - 1; i++) {
            var x = nums[i];
            var y = nums[i+1];
            
            if (x > y) {
                badIndex = i;
            }
        }
        
        var n = nums.Length;
        var k = badIndex < 0 ? 0 : nums.Length - badIndex - 1;
        var m = n - k;
        
        
        var a = 0;
        var b = nums.Length - 1;
        
        while (a <= b) {
            var middle = a + (b-a)/2;
            var middleTransformed = Transform(middle, k, m);
            var middleVal = nums[middleTransformed];
            if (middleVal == target) {
                return middleTransformed;
            }
            else if (middleVal < target) {
                a = middle + 1;
            }
            else if (middleVal > target) {
                b = middle - 1;
            }
        }
        
        return - 1;
    }
}