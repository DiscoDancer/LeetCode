import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    private List<List<Integer>> piles;
    private int maxScore = 0;
    private int k;

    private void F(int taken, int[] indexes, int score) {
        if (taken == k) {
            this.maxScore = Math.max(this.maxScore, score);
            return;
        }

        for (int i = 0; i < indexes.length; i++) {
            if (indexes[i] < piles.get(i).size()) {
                int newScore = score + piles.get(i).get(indexes[i]);
                indexes[i]++;
                F(taken + 1, indexes, newScore);
                indexes[i]--;
            }
        }
    }

    public int maxValueOfCoins(List<List<Integer>> piles, int k) {
        this.k = k;
        this.piles = piles;
        var indexes = new int[piles.size()];

        F(0, indexes, 0);

        return this.maxScore;
    }
}
