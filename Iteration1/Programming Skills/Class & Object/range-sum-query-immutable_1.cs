public class NumArray {
    private readonly int[] _nums;
    private readonly int[] _sums;

    public NumArray(int[] nums) {
        _nums = nums;
        
        _sums = new int[nums.Length];
        var sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            _sums[i] = sum;
        }
    }
    
    public int SumRange(int left, int right) {
        if (left == 0) {
            return _sums[right];
        }
        return _sums[right] - _sums[left - 1];
    }
}