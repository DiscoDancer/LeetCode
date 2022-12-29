public class NumArray {

    private int[] _sums;

    public NumArray(int[] nums) {
        _sums = new int[nums.Length + 1];

        var sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            _sums[i + 1] = _sums[i] + nums[i];
        }
    }
    
    public int SumRange(int left, int right) {
        return _sums[right + 1] - _sums[left];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */