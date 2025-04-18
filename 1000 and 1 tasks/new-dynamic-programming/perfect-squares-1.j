import java.util.ArrayList;
import java.util.HashMap;

class Solution {
    private ArrayList<Integer> listSquares = new ArrayList<>();

    private int F(int n) {
        if (n == 0) {
            return 0;
        }

        var min = Integer.MAX_VALUE;

        for (int i = 0; i < listSquares.size(); i++) {
            int square = listSquares.get(i);
            if (square > n) {
                break;
            }
            min = Math.min(min, F(n - square));
        }

        return min + 1;
    }

    public int numSquares(int n) {
        for (int i = 1; i * i <= n; i++) {
            listSquares.add(i * i);
        }

        return F(n);
    }
}
