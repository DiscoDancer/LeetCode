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

    public int ladderLength(String beginWord, String endWord, List<String> wordList) {
        var visited = new HashSet<String>();

        Queue<String> queue = new ArrayDeque<>();
        queue.add(beginWord);

        if (beginWord.equals(endWord)) {
            return 0;
        }

        var mutationsCount = 1;
        while (!queue.isEmpty()) {
            var size = queue.size();

            for (var i = 0; i < size; i++) {
                var current = queue.poll();
                if (current.equals(endWord)) {
                    return mutationsCount;
                }
                if (!visited.add(current)) {
                    continue;
                }

                for (var s: wordList) {
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

        return 0;
    }
}