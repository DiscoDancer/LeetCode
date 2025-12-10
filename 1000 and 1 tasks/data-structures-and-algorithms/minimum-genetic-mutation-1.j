import java.util.*;


class Solution {

    private boolean isValidDiff(String a, String b) {
        var count = 0;
        for (var i = 0; i < a.length(); i++) {
            if (a.charAt(i) != b.charAt(i)) {
                count++;
                if (count == 2) {
                    return false;
                }
            }
        }

        return count == 1;
    }

    // idea masks grouping
    public int minMutation(String startGene, String endGene, String[] bank) {
        var visited = new HashSet<String>();

        Queue<String> queue = new ArrayDeque<>();
        queue.add(startGene);

        if (startGene.equals(endGene)) {
            return 0;
        }

        var mutationsCount = 0;
        while (!queue.isEmpty()) {
            var size = queue.size();

            for (var i = 0; i < size; i++) {
                var current = queue.poll();
                if (current.equals(endGene)) {
                    return mutationsCount;
                }
                if (!visited.add(current)) {
                    continue;
                }

                for (var s: bank) {
                    if (visited.contains(s)) {
                        continue;
                    }
                    if (isValidDiff(current, s)) {
                        queue.add(s);
                    }
                }
            }
            mutationsCount++;
        }

        return -1;
    }
}