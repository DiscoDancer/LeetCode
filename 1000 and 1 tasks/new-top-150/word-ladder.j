import java.util.Arrays;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

class Solution {
    public int ladderLength(String beginWord, String endWord, List<String> wordList) {
        List<String> bankList = new LinkedList<>(wordList);
        Queue<String> queue = new LinkedList<>();
        queue.add(beginWord);

        int level = 1;
        while (!queue.isEmpty()) {
            var size = queue.size();
            for (int i = 0; i < size; i++) {
                var gene = queue.poll();
                if (gene.equals(endWord)) {
                    return level;
                }
                var suitableGens = new LinkedList<String>();
                for (var candidate: bankList) {
                    var diffCount = 0;
                    for (int j = 0; j < gene.length() && diffCount < 2; j++) {
                        if (gene.charAt(j) != candidate.charAt(j)) {
                            diffCount++;
                        }
                    }
                    if (diffCount == 1) {
                        suitableGens.add(candidate);
                    }
                }
                for (var suitableGene: suitableGens) {
                    queue.add(suitableGene);
                    bankList.remove(suitableGene);
                }
            }
            level++;
        }

        return 0;
    }
}