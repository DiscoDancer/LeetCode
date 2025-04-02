import java.util.Comparator;
import java.util.HashMap;
import java.util.PriorityQueue;

class Solution {

    public record Record (int value, int count) {}

    public int longestSubsequence(int[] arr, int difference) {

        var hashMap = new HashMap<Integer, Integer>();

        var max = 1;
        for (var i = 0; i < arr.length; i++) {

            if (i == 0) {
                hashMap.put(arr[i], 1);
            }
            else {
                var prevValue = arr[i] - difference;
                if (hashMap.containsKey(prevValue)) {
                    var prevCount = hashMap.get(prevValue);
                    var curCount = prevCount + 1;
                    max = Math.max(max, curCount);
                    if (hashMap.containsKey(arr[i])) {
                        hashMap.put(arr[i], Math.max(hashMap.get(arr[i]), curCount));
                    }
                    else {
                        hashMap.put(arr[i], curCount);
                    }
                }
                else {
                    if (!hashMap.containsKey(arr[i])) {
                        hashMap.put(arr[i], 1);
                    }
                }
            }
        }

        return max;
    }
}