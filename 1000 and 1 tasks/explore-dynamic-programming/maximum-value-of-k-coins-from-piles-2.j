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
        var sum = 0;
        for (var i = 0; i <= curPileSize; i++) {
            if (i + takenCount > k) {
                break;
            }

            F(pileIndex + 1, score + sum, takenCount + i);
            if (i < curPileSize) {
                sum += piles.get(pileIndex).get(i);
            }
        }
    }

    public int maxValueOfCoins(List<List<Integer>> piles, int k) {
        this.k = k;
        this.piles = piles;

        F(0, 0, 0);

        return this.max;
    }
}
