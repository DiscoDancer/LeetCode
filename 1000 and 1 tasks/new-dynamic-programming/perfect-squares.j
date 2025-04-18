import java.util.ArrayList;
import java.util.HashMap;

class Solution {
    private ArrayList<Integer> listSquares = new ArrayList<>();

    private int minScore = Integer.MAX_VALUE;

    private void F(int n, int score) {
        if (n == 0) {
            this.minScore = Math.min(this.minScore, score);
            return;
        }

        for (int i = 0; i < listSquares.size(); i++) {
            int square = listSquares.get(i);
            if (square > n) {
                break;
            }
            F(n - square, score + 1);
        }
    }

    public int numSquares(int n) {
        for (int i = 1; i * i <= n; i++) {
            listSquares.add(i * i);
        }

        F(n, 0);

        return this.minScore;
    }
}
