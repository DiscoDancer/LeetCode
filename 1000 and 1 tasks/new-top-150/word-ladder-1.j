import java.util.*;

class Solution {
    public int ladderLength(String beginWord, String endWord, List<String> wordList) {
        var tableMask = new HashMap<String, LinkedList<Integer>>();
        var tableIsUsed = new boolean[wordList.size()];
        for (var si = 0; si < wordList.size(); si++) {
            var s = wordList.get(si);
            var sb = new StringBuilder(s);
            for (int i = 0; i < s.length(); i++) {
                var c = sb.charAt(i);
                sb.setCharAt(i, '*');
                var key = sb.toString();
                var list = tableMask.getOrDefault(key, new LinkedList<>());
                list.add(si);
                tableMask.put(key, list);
                sb.setCharAt(i, c);
            }
        }

        Queue<String> queue = new LinkedList<>();
        queue.add(beginWord);

        int level = 1;
        while (!queue.isEmpty()) {
            int size = queue.size();
            while (size-- > 0) {
                var gene = queue.poll();
                if (gene.equals(endWord)) {
                    return level;
                }

                var sb = new StringBuilder(gene);
                for (int i = 0; i < gene.length(); i++) {
                    var c = sb.charAt(i);
                    sb.setCharAt(i, '*');
                    var key = sb.toString();
                    var list = tableMask.get(key);
                    if (list != null) {
                        for (var si : list) {
                            if (!tableIsUsed[si]) {
                                tableIsUsed[si] = true;
                                queue.add(wordList.get(si));
                            }
                        }
                    }
                    sb.setCharAt(i, c);
                }
            }
            level++;
        }

        return 0;
    }
}