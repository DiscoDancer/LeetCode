import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    private HashMap<Integer, Integer> tableCount = new HashMap<>();
    private Integer[] sortedKeys;

    private int F(int i) {
        if (i >= sortedKeys.length) {
            return 0;
        }

        var noNeedToLockNext = i == sortedKeys.length - 1  || (sortedKeys[i+1] - sortedKeys[i] > 1);
        var take = sortedKeys[i] * tableCount.get(sortedKeys[i]) + F(i + (noNeedToLockNext ? 1 : 2));

        var skip = F(i + 1);

        return Math.max(take, skip);
    }

    public int deleteAndEarn(int[] nums) {
        for (var num : nums) {
            tableCount.put(num, tableCount.getOrDefault(num, 0) + 1);
        }

        // Convert the keySet to an int[] array
        Integer[] keys = tableCount.keySet().toArray(new Integer[0]);
        Arrays.sort(keys);

        this.sortedKeys = keys;

        return F(0);
    }
}
