public class Solution {
    // dp

    private int[] _nums1;
    private int[] _nums2;
    private int _k;
    private int _n;

    private long F(int i, long sum, int k, int min) {
        if (i == _n) {
            if (k == 0) {
                return sum*min;
            }
            return int.MinValue;
        }

        long take = int.MinValue;

        // берем
        if (k > 0) {
            take = F(i+1, sum + _nums1[i], k - 1, Math.Min(min, _nums2[i]));
        }

        // не берем
        long notTake = F(i+1, sum, k, min);

        return Math.Max(take, notTake);
    }

    public long MaxScore(int[] nums1, int[] nums2, int k) {
        _nums1 = nums1;
        _nums2 = nums2;
        _k = k;
        _n = nums1.Length;

        return F(0, 0, k, int.MaxValue);
    }
}