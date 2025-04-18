import java.util.ArrayList;
import java.util.HashMap;

class Solution {
    private ArrayList<Integer> listSquares = new ArrayList<>();

    public int numSquares(int n) {
        var table = new int[n+1];
        for (int i = 1; i <= n; i++) {
            table[i] = Integer.MAX_VALUE;
        }

        for (int i = 1; i * i <= n; i++) {
            listSquares.add(i * i);
            table[i * i] = 1;
        }

        for (var ni = 1; ni <= n; ni++) {
            var min = Integer.MAX_VALUE;
            for (int i = 0; i < listSquares.size(); i++) {
                int square = listSquares.get(i);
                if (square > ni) {
                    break;
                }
                min = Math.min(min, table[ni - square]);
            }
            table[ni] = min + 1;
        }

        return table[n];
    }
}
