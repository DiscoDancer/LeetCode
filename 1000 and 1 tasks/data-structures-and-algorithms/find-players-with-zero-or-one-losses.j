import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

class Solution {
    public List<List<Integer>> findWinners(int[][] matches) {
        var playerToLoseCount = new Integer[100000 + 1];

        for (var match : matches ) {
            var w = match[0];
            var l = match[1];
            if (playerToLoseCount[w] == null) {
                playerToLoseCount[w] = 0;
            }
            if (playerToLoseCount[l] == null) {
                playerToLoseCount[l] = 0;
            }
            playerToLoseCount[l]++;
        }

        var noLoses = new ArrayList<Integer>();
        var oneLose = new ArrayList<Integer>();

        for (int i = 0; i < 100000 + 1; i++) {
            if (playerToLoseCount[i] == null) {
                continue;
            }
            if (playerToLoseCount[i] == 0) {
                noLoses.add(i);
            }
            if (playerToLoseCount[i] == 1) {
                oneLose.add(i);
            }
        }

        var result = new ArrayList<List<Integer>>();
        result.add(noLoses);
        result.add(oneLose);

        return result;
    }
}