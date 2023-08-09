public class Solution {
    private int _max = 0;
    private int[] _nums1;
    private int[] _nums2;

    private void F(int index1, int index2, int currentLength) {
        _max = Math.Max(_max, currentLength);

        if (index1 == _nums1.Length) {
            return;
        }
        if (index2 == _nums2.Length) {
            return;
        }

        if (_nums1[index1] == _nums2[index2]) {
            F(index1 + 1, index2 + 1, currentLength + 1);
        }

        F(index1 + 1, index2, 0);
        F(index1, index2 + 1, 0);
    }

    public int FindLength(int[] nums1, int[] nums2) {
        _nums1 = nums1;
        _nums2 = nums2;

        F(0,0,0);

        return _max;
    }
}