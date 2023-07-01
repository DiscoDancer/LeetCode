public class Solution {
    // просто перебор
    // суммы посчитать заранее

    // какие свойста вывести. Если массив ок, то его над массив тоже ок.
    // мб если рассмотреть весь, то тогда будем просто отсекать слева и справа по тихоньку
    // должно получиться

    // out of memory

    private int _target;
    private int[] _nums;
    private int _result = int.MaxValue;
    private HashSet<(int, int)> _mem = new ();

    private void F(int l, int r, long s) {
        if (_mem.Contains((l,r))) {
            return;
        }

        _result = Math.Min(r-l+1, _result);

        if (l+1 <= r && l+1 < _nums.Length && s - _nums[l] >= _target) {
            F(l+1, r, s - _nums[l]);
        }
        if (r-1 >= l && r-1 >= 0 && s - _nums[r] >= _target) {
            F(l, r-1, s - _nums[r]);
        }

        _mem.Add((l,r));
    }


    public int MinSubArrayLen(int target, int[] nums) {
        _target = target;
        _nums = nums;

        long sum = 0;
        foreach (var n in nums) {
            sum += n;
        }

        if (sum < _target) {
            return 0;
        }

        F(0, nums.Length - 1, sum);

        return _result;
    }
}