import java.math.BigInteger;
import java.util.*;

class Solution {

    // предполагаем, что наше окно всегда валидно

    public int longestOnes(int[] nums, int k) {
        var windowBeginIndexInc = 0;
        var windowEndIndexInc = windowBeginIndexInc + k - 1;
        var max = k;

        // in use
        var zeroCount = 0;
        for (var i = windowBeginIndexInc; i <= windowEndIndexInc; i++) {
            if (nums[i] == 0) {
                zeroCount++;
            }
        }

        var i = windowEndIndexInc + 1;
        while (i < nums.length) {
            // question: todo shift of expand

            // expand
            // окно всегда валидно -> can always expand on 1
            if (nums[i] == 1) {  
                windowEndIndexInc++;
                max = Math.max(max, windowEndIndexInc - windowBeginIndexInc + 1);
            }
            else if (nums[i] == 0) {
                // use zeroes to expand if can
                if (zeroCount < k) {
                    windowEndIndexInc++;
                    max = Math.max(max, windowEndIndexInc - windowBeginIndexInc + 1);
                    zeroCount++;
                }
                // будем сужать пока не станет валидным
                else {
                    // skip 1
                    while (nums[windowBeginIndexInc] == 1) windowBeginIndexInc++;
                    windowBeginIndexInc++;
                    windowEndIndexInc++;
                    max = Math.max(max, windowEndIndexInc - windowBeginIndexInc + 1);
                }
            }


            i++;
        }

        return max;
    }
}
