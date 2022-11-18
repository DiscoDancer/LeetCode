public class Solution {
    
    private int _res = -1;
    
    private void BSearch(int[] nums, int target, int _a, int _b) {
        var a = _a;
        var b = _b;
        while (a <= b) {
            var m = (a + b) / 2;
            if (nums[m] < target) {
                a = m+ 1;
            }
            else if (nums[m] > target) {
                b = m - 1;
            }
            else {
                _res = m;
                return;
            }
        }
    }
    
    public int Search(int[] nums, int target) {
        var a = 0;
        var b = nums.Length - 1;
        
        BSearch(nums, target, a, b);
                
        return _res;
    }
}