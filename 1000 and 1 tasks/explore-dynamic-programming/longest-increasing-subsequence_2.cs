public class Solution {
    private int[] _nums;
    private Dictionary<(int, int), int> _mem = new ();

    private int F(int i, int lowBoundary) {
        if (i == _nums.Length) {
            return 0;
        }
        if (_mem.ContainsKey((i,lowBoundary))) {
            return _mem[(i, lowBoundary)];
        }

        // берем
        if (_nums[i] > lowBoundary) {
            _mem[(i, lowBoundary)] =  Math.Max(F(i+1, lowBoundary), 1 + F(i+1, _nums[i]));
        } else {
            _mem[(i, lowBoundary)] = F(i+1, lowBoundary);;
        }

        return _mem[(i, lowBoundary)];
    }

    // все равно TL
    public int LengthOfLIS(int[] nums) {
        _nums = nums;

        return F(0, int.MinValue);
    }
}