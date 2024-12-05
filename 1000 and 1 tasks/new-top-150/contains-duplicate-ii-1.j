import java.util.*;
import java.util.stream.Collectors;

public class Solution {

    public boolean containsNearbyDuplicate(int[] nums, int k) {

        var hashMap = new HashMap<Integer, Integer>();

        for (int i = 0; i < nums.length; i++) {
            if (hashMap.containsKey(nums[i])) {
                var dist = i - hashMap.get(nums[i]);
                if (dist <= k) {
                    return true;
                }
            }
            hashMap.put(nums[i], i);
        }

        return false;
    }
}