public class Solution {
    private int _result = 0;
    private int[] _nums;
    private int _target;

    // editorial
    private void F(int i, int sum) {
        if (i == _nums.Length) {
            if (sum == _target) {
                _result ++;
            }
        } 
        else {
            F(i + 1, sum + _nums[i]);
            F(i+1, sum - _nums[i]);
        }
    }

    public int FindTargetSumWays(int[] nums, int target) {
        if (nums.Length == 1) {
            return nums[0] == target ? 1 : 0;
        }
        _nums = nums;
        _target = target;

        F(0, 0);

        return _result;
    }
}