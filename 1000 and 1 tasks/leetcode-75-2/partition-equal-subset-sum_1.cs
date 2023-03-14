public class Solution {
    // префиксы, сортировка
    // решить в лоб

    private int[] _nums;
    private bool _result = false;

    private void F(int index, int sum1, int sum2) {
        if (_result) {
            return;
        }
        if (index == _nums.Length) {
            if (sum1 == sum2) {
                _result = true;
            }
            return;
        }

        var curNumber = _nums[index];

        // put in 1
        F(index + 1, sum1 + curNumber, sum2);

        // put in 2
        F(index + 1, sum1, sum2 + curNumber);
    }

    // TL as well
    public bool CanPartition(int[] nums) {
        if (nums.Sum() % 2 == 1) {
            return false;
        }

        _nums = nums;

        F(0, 0, 0);

        return _result;
    }
}