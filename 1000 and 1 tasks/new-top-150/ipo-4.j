import java.util.*;

class Solution {
    public int findMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        var capitalToProfitsTable = new HashMap<Integer, List<Integer>>();

        var n = profits.length;
        for (int i = 0; i < n; i++) {
            var key = capital[i];
            var value = profits[i];
            if (!capitalToProfitsTable.containsKey(key)) {
                capitalToProfitsTable.put(key, new ArrayList<>());
            }
            capitalToProfitsTable.get(key).add(value);
        }

        var capitalToProfitsTableKeys = new ArrayList<>(capitalToProfitsTable.keySet());
        Collections.sort(capitalToProfitsTableKeys);

        var capitalToProfitsTableKeysIndex = 0;
        var maxHeap = new PriorityQueue<Integer>((a, b) -> b - a);

        var currentCapital = w;
        var currentProjects = 0;

        // заливаем новые данные в кучу
        // идея в том, что мы постепенно заливаем в кучу все проекты, которые доступны
        while (capitalToProfitsTableKeysIndex < capitalToProfitsTableKeys.size() && capitalToProfitsTableKeys.get(capitalToProfitsTableKeysIndex) <= currentCapital) {
            var key = capitalToProfitsTableKeys.get(capitalToProfitsTableKeysIndex);
            maxHeap.addAll(capitalToProfitsTable.get(key));
            capitalToProfitsTableKeysIndex++;
        }

        while (currentProjects < k && capitalToProfitsTableKeysIndex < capitalToProfitsTableKeys.size() && capitalToProfitsTableKeys.get(capitalToProfitsTableKeysIndex) <= currentCapital) {
            var currentProfit = maxHeap.poll();
            currentCapital += currentProfit;
            currentProjects++;

            // заливаем новые данные в кучу
            while (capitalToProfitsTableKeysIndex < capitalToProfitsTableKeys.size() && capitalToProfitsTableKeys.get(capitalToProfitsTableKeysIndex) <= currentCapital) {
                var key = capitalToProfitsTableKeys.get(capitalToProfitsTableKeysIndex);
                maxHeap.addAll(capitalToProfitsTable.get(key));
                capitalToProfitsTableKeysIndex++;
            }
        }

        return currentCapital;
    }
}