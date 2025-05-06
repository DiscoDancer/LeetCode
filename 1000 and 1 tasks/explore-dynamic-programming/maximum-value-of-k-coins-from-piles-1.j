import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    private int k;
    List<List<Integer>> piles;
    private int max = 0;

    private void F(int pileIndex, int score, int takenCount) {
        if (takenCount == k) {
            max = Math.max(max, score);
            return;
        }
        if (pileIndex == piles.size()) {
            return;
        }

        var curPileSize = piles.get(pileIndex).size();
        for (var i = 0; i <= curPileSize; i++) {
            if (i + takenCount > k) {
                break;
            }
            var curScore = piles.get(pileIndex).stream().limit(i).collect(Collectors.summingInt(Integer::intValue));
            F(pileIndex + 1, score + curScore, takenCount + i);
        }
    }

    public int maxValueOfCoins(List<List<Integer>> piles, int k) {
        this.k = k;
        this.piles = piles;

        F(0, 0, 0);

        return this.max;
    }
}
