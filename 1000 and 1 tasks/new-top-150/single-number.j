import java.util.*;

class Solution {

    public int singleNumber(int[] nums) {
        var result = 0;

        for (var x: nums) {
            result ^= x;
        }

        return result;
    }
}