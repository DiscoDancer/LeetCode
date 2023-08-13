public class Solution {
    private int[] _nums1;
    private int[] _nums2;

    private int F(int index1, int index2, int currentLength, int max) {
        max = Math.Max(max, currentLength);

        if (index1 == _nums1.Length) {
            return max;
        }
        if (index2 == _nums2.Length) {
            return max;
        }

        var a = 0;
        var b = 0;
        var c = 0;

        if (_nums1[index1] == _nums2[index2]) {
            a = F(index1 + 1, index2 + 1, currentLength + 1, max);
        }

        b = F(index1 + 1, index2, 0, max);
        c = F(index1, index2 + 1, 0, max);

        max = Math.Max(max, a);
        max = Math.Max(max, b);
        max = Math.Max(max, c);

        return max;
    }

    // TL
    public int FindLength(int[] nums1, int[] nums2) {
        _nums1 = nums1;
        _nums2 = nums2;

        return F(0,0,0, 0);
    }
}