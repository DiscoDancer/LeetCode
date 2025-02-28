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
        var maxProfit = Integer.MIN_VALUE;
        var maxProfitIndex = -1;
        for (int i = 0; i < n; i++) {
            if (!visited[i] && curW >= capital[i]) {
                if (profits[i] > maxProfit) {
                    maxProfit = profits[i];
                    maxProfitIndex = i;
                }
            }
        }

        if (maxProfitIndex != -1) {
            visited[maxProfitIndex] = true;
            F(curK + 1, profits[maxProfitIndex] + curW, visited);
            visited[maxProfitIndex] = false;
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