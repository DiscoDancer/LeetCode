import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {
    public int maxValueOfCoins(List<List<Integer>> piles, int k) {
        var table = new int[piles.size() + 1][k + 1];

        for (var pileIndex = piles.size() - 1; pileIndex >= 0; pileIndex--) {
            for (var takenCount = k - 1; takenCount >= 0; takenCount--) {
                var curPileSize = piles.get(pileIndex).size();
                var canMaxTake = Math.min(k - takenCount, curPileSize);
                var sum = 0;
                for (var weTake = 0; weTake <= canMaxTake; weTake++) {
                    table[pileIndex][takenCount] = Math.max(table[pileIndex][takenCount], sum + table[pileIndex + 1][takenCount + weTake]);
                    if (weTake < curPileSize) {
                        sum += piles.get(pileIndex).get(weTake);
                    }
                }
            }
        }

        return table[0][0];
    }
}
