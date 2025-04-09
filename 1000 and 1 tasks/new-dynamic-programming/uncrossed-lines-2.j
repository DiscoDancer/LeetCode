import java.util.*;

// очень важно, почему я убрал циклы
// потому что они для пересечения должны отойти назад, а у нас они ходят только вперед

class Solution {
    public int maxUncrossedLines(int[] nums1, int[] nums2) {

        var table = new int[nums1.length + 1][nums2.length + 1];

        for (var i = nums1.length; i >= 0; i--) {
            for (var j = nums2.length; j >= 0; j--) {
                if (i == nums1.length || j == nums2.length) {
                    table[i][j] = 0;
                }
                else {
                    var max = 0;

                    var skip1 = table[i + 1][j];
                    max = Math.max(max, skip1);

                    var skip2 = table[i][j + 1];
                    max = Math.max(max, skip2);

                    if (nums1[i] == nums2[j]) {
                        var drawLine = 1 + table[i + 1][j + 1];
                        max = Math.max(max, drawLine);
                    }

                    table[i][j] = max;
                }


            }
        }

        return table[0][0];
    }
}