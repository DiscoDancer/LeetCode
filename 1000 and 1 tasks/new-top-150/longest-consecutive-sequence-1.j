import java.util.Arrays;

class Solution {
    public int longestConsecutive(int[] nums) {
        // пихаем все числа в хеш таблицу x -> 1
        // начинаем сжимать, смотрим по соседям. и их ++

        var max = 0;

        var hashMap = new java.util.HashMap<Integer, Integer>();

        for (var num : nums) {
            if (hashMap.containsKey(num)) {
                continue;
            }

            var score = 1;
            if (hashMap.containsKey(num - 1)) {
                score += hashMap.get(num - 1);
            }
            if (hashMap.containsKey(num + 1)) {
                score += hashMap.get(num + 1);
            }

            hashMap.put(num, score);
            if (hashMap.containsKey(num - 1)) {
                hashMap.put(num - hashMap.get(num - 1), score);
            }
            if (hashMap.containsKey(num + 1)) {
                hashMap.put(num + hashMap.get(num + 1), score);
            }

            max = Math.max(max, score);
        }

        return max;
    }
}