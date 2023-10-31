public class Solution {
    // dp

    private long _result = long.MinValue;

    private int[] _nums1;
    private int[] _nums2;
    private int _k;
    private int _n;

    private void F(int i, long sum, int k, int min) {
        if (i == _n) {
            if (k == 0) {
                _result = Math.Max(_result, sum*min);
            }
            return;
        }

        // берем
        if (k > 0) {
            F(i+1, sum + _nums1[i], k - 1, Math.Min(min, _nums2[i]));
        }

        // не берем
        F(i+1, sum, k, min);
    }

    // TL
    public long MaxScore(int[] nums1, int[] nums2, int k) {
        _nums1 = nums1;
        _nums2 = nums2;
        _k = k;
        _n = nums1.Length;

        F(0, 0, k, int.MaxValue);

        return _result;
    }
}