public class NumArray {
    private readonly int[] _nums;

    public NumArray(int[] nums) {
        _nums = nums;
    }
    
    public int SumRange(int left, int right) {
        var res = 0;
        
        var L = left;
        var R = right;
        
        while (L <= R) {
            res += _nums[L];
            L++;
        }
        
        return res;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */