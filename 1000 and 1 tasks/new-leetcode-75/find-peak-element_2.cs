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

    private void Search(int l, int r) {
        if (l > r || _result != null) {
            return;
        }
        else if (l == r) {
            F(l);
            return;
        }
        else {
            var m = l + (r-l)/2;
            // тут можно отсекать 
            Search(l, m);
            Search(m+1,r);
        }
    }

    public int FindPeakElement(int[] nums) {
        _nums = nums;
        Search(0, _nums.Length - 1);

        return _result.Value;
    }
}