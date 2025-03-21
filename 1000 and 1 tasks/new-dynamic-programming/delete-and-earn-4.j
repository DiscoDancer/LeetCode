import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int deleteAndEarn(int[] nums) {
        HashMap<Integer, Integer> tableCount = new HashMap<>();
        for (var num : nums) {
            tableCount.put(num, tableCount.getOrDefault(num, 0) + 1);
        }

        // Convert the keySet to an int[] array
        Integer[] keys = tableCount.keySet().toArray(new Integer[0]);
        Arrays.sort(keys);

        var prevPrev = 0;
        var prev = 0;

        for (var i = keys.length - 1; i >= 0; i--) {
            var noNeedToLockNext = i == keys.length - 1  || (keys[i+1] - keys[i] > 1);
            var take = keys[i] * tableCount.get(keys[i]) + (noNeedToLockNext ? prev : prevPrev);
            var skip = prev;
            var cur = Math.max(take, skip);
            
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}
