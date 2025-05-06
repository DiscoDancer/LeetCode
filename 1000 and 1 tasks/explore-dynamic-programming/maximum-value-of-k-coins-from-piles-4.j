import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    private int k;
    List<List<Integer>> piles;

    private int F(int pileIndex, int takenCount) {
        if (takenCount == k) {
            return 0;
        }
        if (pileIndex == piles.size()) {
            return 0;
        }

        var curPileSize = piles.get(pileIndex).size();
        var canMaxTake = Math.min(k - takenCount, curPileSize);
        var sum = 0;
        var result = 0;
        for (var weTake = 0; weTake <= canMaxTake; weTake++) {
            result = Math.max(result, sum + F(pileIndex + 1, takenCount + weTake));
            if (weTake < curPileSize) {
                sum += piles.get(pileIndex).get(weTake);
            }
        }

        return result;
    }

    public int maxValueOfCoins(List<List<Integer>> piles, int k) {
        this.k = k;
        this.piles = piles;

        return F(0, 0);
    }
}
