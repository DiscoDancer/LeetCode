import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Solution {
    public int largestUniqueNumber(int[] nums) {
        var table = new int[1000+1];
        for (var x: nums) {
            table[x]++;
        }

        for (var i = 1000; i >= 0; i--) {
            if (table[i] == 1) {
                return i;
            }
        }

        return -1;
    }
}