import java.util.Comparator;
import java.util.HashMap;
import java.util.PriorityQueue;

// ускорение предыдущего

class Solution {

    public record Record (int value, int count) {}

    public int longestSubsequence(int[] arr, int difference) {

        var hashMap = new HashMap<Integer, PriorityQueue<Record>>();

        var max = 1;
        for (var i = 0; i < arr.length; i++) {

            if (i == 0) {
                hashMap.put(arr[i], new PriorityQueue<>(Comparator.comparingInt(Record::count).reversed()));
                hashMap.get(arr[i]).offer(new Record(arr[i], 1));
            }
            else {
                var prevValue = arr[i] - difference;
                if (hashMap.containsKey(prevValue)) {
                    var queue = hashMap.get(prevValue);
                    var record = queue.peek();
                    if (record != null) {
                        max = Math.max(max, record.count + 1);
                        if (!hashMap.containsKey(arr[i])) {
                            hashMap.put(arr[i], new PriorityQueue<>(Comparator.comparingInt(Record::count).reversed()));
                        }
                        hashMap.get(arr[i]).offer(new Record(arr[i], record.count + 1));
                    }
                }
                else {
                    if (!hashMap.containsKey(arr[i])) {
                        hashMap.put(arr[i], new PriorityQueue<>(Comparator.comparingInt(Record::count).reversed()));
                    }
                    hashMap.get(arr[i]).offer(new Record(arr[i], 1));
                }
            }
            var stop = true;
        }

        return max;
    }
}