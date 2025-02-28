import java.util.Arrays;
import java.util.Collections;
import java.util.PriorityQueue;

// TL

class Solution {

    private int[] profits;
    private int[] capital;
    private int k;
    private int max = 0;

    private void F(int curK, int curW, boolean[] visited) {
        this.max = Math.max(this.max, curW);

        if (curK >= this.k) {
            return;
        }

        var n = this.profits.length;
        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                // делаем backtracking здесь
                if (curW >= capital[i]) {
                    var visitedCopy = visited.clone();
                    visitedCopy[i] = true;
                    F(curK + 1, profits[i] + curW, visitedCopy);
                }
                // visited[i] = true;
            }
        }
    }

    public int findMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        this.capital = capital;
        this.profits = profits;
        this.k = k;

        var n = profits.length;
        var visited = new boolean[n];

        F(0, w, visited);

        return this.max;
    }
}