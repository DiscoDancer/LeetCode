public class NumArray {

    private int[] _nums;

    public NumArray(int[] nums) {
        _nums = nums;
    }
    
    public int SumRange(int left, int right) {
        var sum = 0;
        while (left <= right) {
            sum += _nums[left++];
        }

        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */