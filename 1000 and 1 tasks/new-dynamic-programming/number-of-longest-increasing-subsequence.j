import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


class Solution {

    public record Entry (int length, int count) {
    }

    public int findNumberOfLIS(int[] nums) {
        var stateTable = new Entry[nums.length];

        for (var i = 0; i < nums.length; i++) {
            if (i == 0) {
                stateTable[i] = new Entry(1, 1);
                continue;
            }

            var maxLength = 0;
            var j = i - 1;
            while (j >= 0) {
                if (nums[j] < nums[i]) {
                    maxLength = Math.max(maxLength, stateTable[j].length);
                }
                j--;
            }
            if (maxLength == 0) {
                stateTable[i] = new Entry(1, 1);
                continue;
            }

            var count = 0;
            j = i - 1;
            while (j >= 0) {
                if (nums[j] < nums[i] && stateTable[j].length == maxLength) {
                    count += stateTable[j].count;
                }
                j--;
            }
            stateTable[i] = new Entry(maxLength + 1, count);
        }

        var maxLength = 0;
        for (var i = 0; i < stateTable.length; i++) {
            maxLength = Math.max(maxLength, stateTable[i].length);
        }

        var maxCount = 0;
        for (var i = 0; i < stateTable.length; i++) {
            if (stateTable[i].length == maxLength) {
                maxCount += stateTable[i].count;
            }
        }

        return maxCount;
    }
}
