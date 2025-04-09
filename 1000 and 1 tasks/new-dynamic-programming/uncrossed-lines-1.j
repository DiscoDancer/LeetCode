import java.util.*;

// очень важно, почему я убрал циклы
// потому что они для пересечения должны отойти назад, а у нас они ходят только вперед

class Solution {

    private int[] nums1;
    private int[] nums2;

    private Integer[][] memo;

    private int F(int i, int j) {
        if (i >= nums1.length || j >= nums2.length) {
            return 0;
        }
        if (memo[i][j] != null) {
            return memo[i][j];
        }

        var max = 0;

        var skip1 = F(i + 1, j);
        max = Math.max(max, skip1);

        var skip2 = F(i, j + 1);
        max = Math.max(max, skip2);

        if (nums1[i] == nums2[j]) {
            var drawLine = 1 + F(i + 1, j + 1);
            max = Math.max(max, drawLine);
        }

        memo[i][j] = max;

        return max;
    }

    public int maxUncrossedLines(int[] nums1, int[] nums2) {
        this.nums1 = nums1;
        this.nums2 = nums2;

        this.memo = new Integer[nums1.length + 1][nums2.length + 1];

        return F(0, 0);
    }
}