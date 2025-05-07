import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

// nlogm

class Solution {

    private int findFirstNegativeIndex(int[] arr) {
        var l = 0;
        var r = arr.length - 1;
        while (l <= r) {
            var m = l + (r - l) / 2;
            if (arr[m] < 0) {
                if (m == 0 || arr[m - 1] >= 0) {
                    return m;
                }
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return -1;
    }

    public int countNegatives(int[][] grid) {
        var result = 0;
        for (var arr: grid) {
            var firstNegativeIndex = findFirstNegativeIndex(arr);
            if (firstNegativeIndex != -1) {
                result += arr.length - firstNegativeIndex;
            }
        }

        return result;
    }
}
