public class Solution {
    // написать псевдо бинарный поиск

    private int[] _nums;
    private int? _result;

    private void F(int i) {
            if (_nums.Length == 1) {
                _result = i;
            }
            else if (i == 0 && _nums.Length > 1 && _nums[i] > _nums[i+1]) {
                _result = i;
            }
            else if (i == _nums.Length - 1 && _nums.Length > 1 && _nums[i-1] < _nums[i]) {
                _result = i;
            }
            else if (_nums.Length > 2 && i > 0 && i < _nums.Length - 1 && _nums[i-1] < _nums[i] && _nums[i] > _nums[i+1]) {
                _result = i;
            }
    }

    public int FindPeakElement(int[] nums) {
        _nums = nums;


        for (int i = 0; i < nums.Length; i++) {
            F(i);
            if (_result != null) {
                return i;
            }
        }

        return 0;
    }
}