// https://leetcode.com/problems/cheapest-flights-within-k-stops/submissions/
public class Solution {
    // n cities 0..n-1
    // src -> target
    // most k stops
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        var prevLine = new int[n];
        Array.Fill(prevLine, int.MaxValue);
        prevLine[src] = 0;
        int[] curLine = prevLine;

        for (int row = 0; row < k+1; row++) { // count of edges
            curLine = prevLine.ToArray();

            foreach (var flight in flights) {
                var from = flight[0];
                var to = flight[1];
                var cost = flight[2];

                if (prevLine[from] != int.MaxValue) {
                    curLine[to] = Math.Min(curLine[to], prevLine[from] + cost);
                }
            }

            prevLine = curLine;
        }

        return curLine[dst] == int.MaxValue ? -1 : curLine[dst];
    }
}