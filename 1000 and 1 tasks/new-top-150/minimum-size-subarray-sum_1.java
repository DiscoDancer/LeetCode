import java.util.Arrays;
import java.util.Collections;

// editorila

public class Solution {

    // put last K in queue
    // мне надо просто оптимизировать это говно
    // что будет если я буду по очереди выкидывать слева или справа

    // мб написать рекурсивное выражение

    public int minSubArrayLen(int target, int[] nums) {
        int left = 0, right = 0, sumOfCurrentWindow = 0;
        int res = Integer.MAX_VALUE;

        for(right = 0; right < nums.length; right++) {
            sumOfCurrentWindow += nums[right];

            while (sumOfCurrentWindow >= target) {
                res = Math.min(res, right - left + 1);
                sumOfCurrentWindow -= nums[left++];
            }
        }

        return res == Integer.MAX_VALUE ? 0 : res;
    }
}