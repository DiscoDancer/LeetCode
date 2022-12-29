public class NumArray {

    private int[] _nums;
    private Dictionary<(int, int), int> _cache = new ();

    public NumArray(int[] nums) {
        _nums = nums;
    }
    
    public int SumRange(int left, int right) {
        if (_cache.ContainsKey((left, right))) {
            return _cache[(left, right)];
        }

        var sum = 0;
        while (left <= right) {
            sum += _nums[left++];
        }

        _cache[(left, right)] = sum;

        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */