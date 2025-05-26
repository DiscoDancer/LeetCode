import java.util.*;

class Solution {

    public int twoSumLessThanK(int[] nums, int k) {
        var table = new int[1001];
        for (var x: nums) {
            table[x] += 1;
        }

        var l = 1;
        var r = 1000;

        var max = -1;

        while (l <= r || table[l] > 1) {
            // shift until value
            while (table[l] == 0) {
                l++;
            }
            while (table[r] == 0) {
                r--;
            }
            if (l == r && table[l] < 2) {
                break;
            }
            var sum = l + r;
            if (sum < k) {
                max = Math.max(max, sum);
                l++;
            } else {
                r--;
            }
            var stop = false;
        }

        return max;
    }
}
